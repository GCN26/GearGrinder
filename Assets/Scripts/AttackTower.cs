using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackTower : MainTower
{
    public float attackTimer = 0;
    public float attackTimerTarget = 1.5f;
    public float attackTimerTargetBuffed = .75f;
    public float attackTimerTargetSet = 1.5f;
    public List<GameObject> targets;
    public GameObject searchRadius;
    public GameObject displaySearch;
    public GameObject head;
    public float damage;

    public AudioClip soundFire;

    public override void Start()
    {
        base.Start();
    }
    //add values for damage - subject to change
    public override void OnMouseOver()
    {
        base.OnMouseOver();
        highlighted2 = true;
    }
    public override void OnMouseExit()
    {
        base.OnMouseExit();
        highlighted2 = false;
    }
    public override void Update()
    {
        base.Update();
        displaySearch.SetActive(highlighted2);

        if (buffed)
        {
            attackTimerTargetSet = attackTimerTargetBuffed;
        }
        else
        {
            attackTimerTargetSet = attackTimerTarget;
        }

        if (leeched != true)
        {
            if (targets.Count > 0)
            {
                attackTimer += Time.deltaTime;
                BarrelRotate(targets[0]);
            }
            else attackTimer = 0;

            if (attackTimer >= attackTimerTargetSet)
            {
                attackTimer = 0;
                targets[0].GetComponent<BaseEnemyScript>().Damaged(damage);
                sound.PlayOneShot(soundFire,0.75f);
                if(targets[0].GetComponent<BaseEnemyScript>().invulnerable == false) hp -= 1;
            }
        }

        for(int i = 0;i< targets.Count; i++)
        {
            if (targets[i] == null)
            {
                targets.RemoveAt(i);
            }
            if (targets[i].tag != "Enemy")
            {
                targets.RemoveAt(i);
            }
        }
    }

    public void BarrelRotate(GameObject target)
    {
        Vector3 enemyPos = target.transform.position;
        enemyPos.z = head.transform.position.z;

        Vector3 handToMouse =  enemyPos - head.transform.position;
        head.transform.right = handToMouse;

        Vector3 localRotation = head.transform.localEulerAngles;
        localRotation.x = 0;
        head.transform.localEulerAngles = localRotation;
    }

    private void OnDestroy()
    {
        targets = null;
    }

    public override void UpgradeFunction()
    {
        if (level == 1)
        {
            attackTimerTarget = 1.5f;
            attackTimerTargetBuffed = .75f;
            searchRadius.transform.localScale = new Vector3(5, 5, 1);
            displaySearch.transform.localScale = new Vector3(5, 5, 1);
            maxHP = 10;
            damage = 1;
            upgradeObj.GetComponent<SpriteRenderer>().sprite = null;
        }
        else if (level == 2)
        {
            attackTimerTarget = 1f;
            attackTimerTargetBuffed = .5f;
            searchRadius.transform.localScale = new Vector3(6, 6, 1);
            displaySearch.transform.localScale = new Vector3(6, 6, 1);
            maxHP = 20;
            damage = 3;
            upgradeObj.GetComponent<SpriteRenderer>().sprite = upgrade1;
        }
        else if (level == 3)
        {
            attackTimerTarget = 1f;
            attackTimerTargetBuffed = .5f;
            searchRadius.transform.localScale = new Vector3(7.5f, 7.5f, 1);
            displaySearch.transform.localScale = new Vector3(7.5f, 7.5f, 1);
            maxHP = 35;
            damage = 3;
            upgradeObj.GetComponent<SpriteRenderer>().sprite = upgrade2;
        }
        base.UpgradeFunction();
    }
}
