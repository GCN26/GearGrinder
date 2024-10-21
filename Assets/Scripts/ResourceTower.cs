using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourceTower : MainTower
{
    public float gatherTimer;
    public float gatherTimerTarget = 5;
    public float gatherTimerTargetBuffed = 2.5f;
    public float gatherTimerTargetSet = 5;

    public int moneyPerHarvest = 50;

    public Slider gatherSlider;
    //money per harvest values subject to change

    public override void Update()
    {
        base.Update();

        if (buffed)
        {
            gatherTimerTargetSet = gatherTimerTargetBuffed;
        }
        else
        {
            gatherTimerTargetSet = gatherTimerTarget;
        }

        if (leeched != true)
        {
            gatherTimer += Time.deltaTime;
            gatherSlider.value = gatherTimer / gatherTimerTargetSet;
            if (gatherTimer >= gatherTimerTargetSet)
            {
                gatherTimer = 0;
                selectionManager.GetComponent<SelectionManager>().money += moneyPerHarvest;
                hp -= 1;
            }
        }
        else
        {

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
