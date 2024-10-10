using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor.Tilemaps;
using UnityEditor.UI;
using UnityEngine;

public class TowerGrid : MonoBehaviour
{
    private bool highlighted;
    public GameObject gridManager;

    private void OnMouseOver()
    {
        highlighted = true;
    }
    private void OnMouseExit()
    {
        highlighted = false;
    }

    private void Update()
    {
        //if grid is selected and no tower is already on that space, if click, build tower
        GameObject towerGhost = null;
        if (highlighted)
        {
            if (!GameObject.Find("TowerGhost" + this.name))
            {
                towerGhost = Instantiate(gridManager.GetComponent<SelectionManager>().selectedTower, transform.position, transform.rotation);
                towerGhost.name = "TowerGhost" + this.name;
            }
        }
        if (highlighted == false)
        {
            Destroy(GameObject.Find("TowerGhost" + this.name));
        }
    }
}