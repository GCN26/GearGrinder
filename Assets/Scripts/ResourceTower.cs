using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourceTower : MainTower
{
    public float gatherTimer;
    public float gatherTimerTarget = 4.5f;
    public float gatherTimerTargetBuffed = 3f;
    public float gatherTimerTargetSet = 4.5f;

    public int moneyPerHarvest = 50;

    public Slider gatherSlider;
    public AudioClip gatherSound;

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
                sound.PlayOneShot(gatherSound, 0.75f);
                hp -= 2;
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
            moneyPerHarvest = 75;
            maxHP = 10;
            upgradeObj.GetComponent<SpriteRenderer>().sprite = null;
        }
        else if (level == 2)
        {
            moneyPerHarvest = 100;
            maxHP = 20;
            upgradeObj.GetComponent<SpriteRenderer>().sprite = upgrade1;
        }
        else if (level == 3)
        {
            moneyPerHarvest = 175;
            maxHP = 35;
            upgradeObj.GetComponent<SpriteRenderer>().sprite = upgrade2;
        }
        base.UpgradeFunction();
    }
}
