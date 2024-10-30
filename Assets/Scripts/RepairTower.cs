using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepairTower : MainTower
{
    public float dieTimer;
    public AudioClip repairSound;

    public override void Start()
    {
        base.Start();
        sound.PlayOneShot(repairSound, 0.75f);
    }
    public override void Update()
    {
        base.Update();
        dieTimer += Time.deltaTime;
        if( dieTimer > .5)
        {
            hp = 0;
        }
    }
}
