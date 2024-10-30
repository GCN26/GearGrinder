using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackTower2 : MainTower
{
    public float attackTimer = 0;
    public float attackTimerTarget = 3f;
    public float attackTimerTargetBuffed = 1.5f;
    public float attackTimerTargetSet = 3f;
    public List<GameObject> targets;
    public GameObject searchRadius;
    public GameObject displaySearch;
    public GameObject head;
    public float damage;

    public GameObject zapCircle;
    public float zapShowTimer;
    public float zapShowTarget;

    public Sprite inactive;
    public Sprite active;

    public AudioClip soundFire;

    public override void Start()
    {
        base.Start();
        zapCircle.SetActive(false);
        displaySearch.SetActive(false);
    }

    public override void OnMouseOver()
    {
        base.OnMouseOver();
    }
    public override void OnMouseExit()
    {
        base.OnMouseExit();
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

        if (zapShowTimer < zapShowTarget)
        {
            zapShowTimer += Time.deltaTime;
            zapCircle.SetActive(true);
            towerTop.GetComponent<SpriteRenderer>().sprite = active;
        }
        else
        {
            zapCircle.SetActive(false);
            towerTop.GetComponent<SpriteRenderer>().sprite = inactive;
        }
        if (leeched != true)
        {
            if (targets.Count > 0)
            {
                attackTimer += Time.deltaTime;
                //rotate head to face target
            }
            else attackTimer = 0;

            if (attackTimer >= attackTimerTargetSet)
            {
                attackTimer = 0;
                zapShowTimer = 0;
                for (int i = 0; i < targets.Count; i++)
                {
                    targets[i].GetComponent<BaseEnemyScript>().Damaged(damage);
                    sound.PlayOneShot(soundFire, 0.75f);
                }
                hp -= 1;

            }
        }

        for (int i = 0; i < targets.Count; i++)
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
    private void OnDestroy()
    {
        targets = null;
    }

    public override void UpgradeFunction()
    {
        if (level == 1)
        {
            attackTimerTarget = 3f;
            attackTimerTargetBuffed = 1.5f;
            searchRadius.transform.localScale = new Vector3(5, 5, 1);
            displaySearch.transform.localScale = new Vector3(5, 5, 1);
            zapCircle.transform.localScale = new Vector3(5, 5, 1);
            maxHP = 10;
            damage = 1;
            upgradeObj.GetComponent<SpriteRenderer>().sprite = null;
        }
        else if (level == 2)
        {
            attackTimerTarget = 2f;
            attackTimerTargetBuffed = 1f;
            searchRadius.transform.localScale = new Vector3(6, 6, 1);
            displaySearch.transform.localScale = new Vector3(6, 6, 1);
            zapCircle.transform.localScale = new Vector3(6, 6, 1);
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
            zapCircle.transform.localScale = new Vector3(7.5f, 7.5f, 1);
            maxHP = 35;
            damage = 5;
            upgradeObj.GetComponent<SpriteRenderer>().sprite = upgrade2;
        }
        base.UpgradeFunction();
    }
}
