using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class LeechEnemy : BaseEnemyScript
{
    public GameObject searchRadius;
    public float searchTimer;
    public float searchTimerTarget;
    public List<GameObject> towers;
    public List<GameObject> preferedTowers;
    public GameObject friend;
    public GameObject Moveable;

    public float jumpTimer;
    public float jumpTimerTarget;
    public float speedJump;
    public float jumpDist;
    public float jumpDist2;
    public bool jumpSelect = false;
    public bool activeLeech = false;
    public bool stopAll = false;
    public bool playsound = true;
    public bool playsound2 = true;

    public AudioClip sfx;
    public AudioClip attachsound;
    public AudioSource sfxSource;

    //The leech has a radius where it attempts to find buff and resource towers
    //If it cannot find any within a few seconds of spawning or none exist, it will attempt to search for attack towers
    //If none exist, it simply moves towards the end
    public override void Start()
    {
        maxHP = 10;
        sfxSource = GetComponent<AudioSource>();
        base.Start();
    }
    public override void Update()
    {
        base.Update();
        if (stopAll == false)
        {

            for (int i = 0; i < towers.Count; i++)
            {
                if (towers[i] == null)
                {
                    towers.RemoveAt(i);
                }
            }
            for (int i = 0; i < preferedTowers.Count; i++)
            {
                if (preferedTowers[i] == null)
                {
                    preferedTowers.RemoveAt(i);
                }
            }
            if (towers.Count > 0)
            {
                searchTimer += Time.deltaTime;
            }
            else
            {
                searchTimer = 0;
            }
            if (searchTimer >= searchTimerTarget && towers.Count > 0 && preferedTowers.Count == 0)
            {
                if (jumpSelect == false)
                {
                    jumpSelect = true;
                    jumpDist = Vector3.Distance(this.transform.position, towers[0].transform.position);
                }
                speed = 0;
                jumpTimer += Time.deltaTime;
                towers[0].GetComponent<MainTower>().leechTarget = true;
                if (jumpTimer >= jumpTimerTarget)
                {
                    JumpFunction(towers[0]);
                }
            }
            if (preferedTowers.Count > 0)
            {
                if (jumpSelect == false)
                {
                    jumpSelect = true;
                    jumpDist = Vector3.Distance(this.transform.position, preferedTowers[0].transform.position);
                }
                speed = 0;
                preferedTowers[0].GetComponent<MainTower>().leechTarget = true;
                jumpTimer += Time.deltaTime;
                if (jumpTimer >= jumpTimerTarget)
                {
                    JumpFunction(preferedTowers[0]);
                }
            }
        }
        else
        {
            hpSlider.gameObject.SetActive(false);
            shieldSlider.gameObject.SetActive(false);
            //small stuff for leeching
            //remove hp bar
            if (friend == null)
            {
                
                hp = 0;
            }
        }
    }

    public void SelfRotate(GameObject target)
    {
        float extraRotate = 0;
        if(target.transform.position.x - enemyObject.transform.position.x > 0)
        {
            //if tower is on the right of leech
            extraRotate = 90;
        }
        else if (target.transform.position.x - enemyObject.transform.position.x < 0)
        {
            //if tower is on the left of leech
            extraRotate = -90;
        }
        Vector3 enemyPos = target.transform.position;
        enemyPos.z = enemyObject.transform.position.z;

        Vector3 handToMouse = enemyPos - enemyObject.transform.position;
        enemyObject.transform.right = handToMouse;

        Vector3 localRotation = enemyObject.transform.localEulerAngles;
        localRotation.z = localRotation.z + extraRotate;
        localRotation.x = 0;
        enemyObject.transform.localEulerAngles = localRotation;
    }
    public void JumpFunction(GameObject tower)
    {
        if (playsound)
        {
            sfxSource.PlayOneShot(sfx, .5f);
            playsound = false;
        }
        SelfRotate(tower);
        //Add visuals for the jump using Moveable
        if (activeLeech == false)
        {
            jumpDist2 = Vector3.Distance(this.transform.position, tower.transform.position);
        }
        else
        {
            jumpDist2 = 0;
            stopAll = true;
        }
        Moveable.transform.position = new Vector3 (this.transform.position.x, this.transform.position.y + Mathf.Sin(jumpDist2 / jumpDist * Mathf.PI)*1.5f, this.transform.position.z);
        gameObject.tag = "ActiveLeech";
        friend = tower;
        Vector3 targetPosition = friend.transform.position;
        Vector3 direction = targetPosition - this.transform.position;
        direction = direction.normalized;

        this.transform.position += direction * speedJump * Time.deltaTime;

        if (Vector3.Distance(targetPosition, this.transform.position) < .25)
        {
            speedJump = 0;
            this.transform.position = new Vector3(friend.transform.position.x, friend.transform.position.y, friend.transform.position.z-.105f);
            friend.GetComponent<MainTower>().leeched = true;
            activeLeech = true;
            if (playsound2)
            {
                sfxSource.PlayOneShot(attachsound, .5f);
                playsound2 = false;
            }
        }
    }

    public override void PathFunction()
    {
        Vector3 targetPosition = nodes[currentNode].transform.position;
        Vector3 direction = targetPosition - this.transform.position;
        direction = direction.normalized;

        this.transform.position += direction * speed * Time.deltaTime;

        if (Vector3.Distance(targetPosition, this.transform.position) < tolerance)
        {
            currentNode = currentNode + 1;
            currentNode = currentNode % nodes.Length;
            enemyObject.transform.eulerAngles = new Vector3(
                enemyObject.transform.eulerAngles.x,
                enemyObject.transform.eulerAngles.y,
                rotateTo
                );
        }
    }

}
