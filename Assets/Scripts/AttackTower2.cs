using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackTower2 : MainTower
{
    public float attackTimer = 0;
    public float attackTimerTarget = 3f;
    public List<GameObject> targets;
    public GameObject searchRadius;
    public GameObject head;
    public int damage;

    public GameObject zapCircle;
    public float zapShowTimer;
    public float zapShowTarget;

    public override void Start()
    {
        base.Start();
        zapCircle.SetActive(false);
    }
    public override void Update()
    {
        base.Update();

        if(zapShowTimer < zapShowTarget)
        {
            zapShowTimer += Time.deltaTime;
            zapCircle.SetActive(true);
        }
        else zapCircle.SetActive(false);
        {
            
        }

        if (targets.Count > 0)
        {
            attackTimer += Time.deltaTime;
            //rotate head to face target
        }
        else attackTimer = 0;

        if (attackTimer >= attackTimerTarget)
        {
            attackTimer = 0;
            zapShowTimer = 0;
            for(int i = 0; i < targets.Count; i++) {
                targets[0].GetComponent<BaseEnemyScript>().Damaged(damage);
            }
            
        }

        for (int i = 0; i < targets.Count; i++)
        {
            if (targets[i] == null)
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
            searchRadius.transform.localScale = new Vector3(5, 5, 1);
            zapCircle.transform.localScale = new Vector3(5, 5, 1);
            maxHP = 10;
            damage = 1;
        }
        else if (level == 2)
        {
            attackTimerTarget = 2f;
            searchRadius.transform.localScale = new Vector3(6, 6, 1);
            zapCircle.transform.localScale = new Vector3(6, 6, 1);
            maxHP = 20;
            damage = 3;
        }
        else if (level == 3)
        {
            attackTimerTarget = 1f;
            searchRadius.transform.localScale = new Vector3(7.5f, 7.5f, 1);
            zapCircle.transform.localScale = new Vector3(7.5f, 7.5f, 1);
            maxHP = 35;
            damage = 5;
        }
        base.UpgradeFunction();
    }
}
