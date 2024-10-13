using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceTower : MainTower
{
    public float gatherTimer;
    public float gatherTimerTarget;

    public int moneyPerHarvest = 50;
    //money per harvest values subject to change

    public override void Update()
    {
        base.Update();
        //if not leeched
        gatherTimer += Time.deltaTime;
        if(gatherTimer >= gatherTimerTarget)
        {
            gatherTimer = 0;
            selectionManager.GetComponent<SelectionManager>().money += moneyPerHarvest;
        }
    }
    public override void UpgradeFunction()
    {
        if (level == 1)
        {
            moneyPerHarvest = 50;
            maxHP = 10;
        }
        else if (level == 2)
        {
            moneyPerHarvest = 100;
            maxHP = 20;
        }
        else if (level == 3)
        {
            moneyPerHarvest = 200;
            maxHP = 35;
        }
        base.UpgradeFunction();
    }
}
