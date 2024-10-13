using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor.Tilemaps;
using UnityEditor.UI;
using UnityEngine;

public class TowerGrid : BaseTowerScript
{
    private GameObject tower = null;
    

    private void OnMouseOver()
    {
        if (gridManager.GetComponent<SelectionManager>().selectedTower != upgradeTower)
        {
            highlighted = true;
        }
    }

    private void OnMouseDown()
    {
        //if tower is attack, resource, or maintenance
        //no upgrades
        if (highlighted && gridManager.GetComponent<SelectionManager>().selectedTower != upgradeTower)
        {
            tower = Instantiate(gridManager.GetComponent<SelectionManager>().selectedTower,transform.position, transform.rotation);
            tower.name = "Tower" + this.name;
            tower.GetComponent<BaseTowerScript>().gridManager = gridManager;
            highlighted = false;
            Destroy(towerGhost);
            Destroy(gameObject);
        }
    }

}