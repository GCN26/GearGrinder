using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainTower : BaseTowerScript
{
    public int level = 0;

    private void OnMouseOver()
    {
        if (level < 3)
        {
            if (gridManager.GetComponent<SelectionManager>().selectedTower == upgradeTower)
            {
                highlighted = true;
            }
        }
    }

    private void OnMouseDown()
    {
        //if tower is upgrade
        if (highlighted && gridManager.GetComponent<SelectionManager>().selectedTower == upgradeTower)
        {
            level += 1;
            highlighted = false;
            Destroy(towerGhost);
        }
    }
}
