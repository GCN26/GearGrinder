using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankEnemy : BaseEnemyScript
{
    public override void Start()
    {
        maxHP = 300;
        base.Start();
    }
}
