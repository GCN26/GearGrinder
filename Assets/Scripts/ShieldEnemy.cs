using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldEnemy : PawnEnemy
{
    //shield enemy has a shield that if broken, turns the enemy into a pawn
    //if the shield is damaged but not broken, a timer starts and repairs the shield to full after a few seconds.
    public GameObject shield;

    public float shieldTimer;
    public float shieldTarget;

    public override void Start()
    {
        base.Start();
        shieldHP = shieldMaxHP;
    }
    public override void Damaged(float damage)
    {
        if (invulnerable == false)
        {
            //if shield is down
            if (shield.activeSelf == false)
            {
                base.Damaged(damage);
            }
            else
            {
                shieldHP -= damage;
                shieldTimer = 0;
            }
        }
        //else if shield is up
        //deal damage to shield
        //reset shield timer
    }
    //update
    //if shield is up and damaged, start timer for a few seconds, if 0 is reached, heal shield one hp per .5 seconds
    public override void Update()
    {
        base.Update();
        if (shield.activeSelf != false)
        {
            if(shieldTimer >= shieldTarget)
            {
                shieldHP = shieldMaxHP;
            }
            else
            {
                shieldTimer += Time.deltaTime;
            }
        }
        if(shieldHP <= 0)
        {
            shield.SetActive(false);
        }
    }
}
