using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class TowerGrid : BaseTowerScript
{
    private GameObject tower = null;

    private void Start()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.y * .1f);
    }
    public override void OnMouseOver()
    {
        if (selectionManager.GetComponent<SelectionManager>().selectedTower != upgradeTower)
        {
            highlighted = true;
        }
    }

    public override void OnMouseDown()
    {
        //if tower is attack, resource, or maintenance and there is enough money
        //no upgrades
        if (highlighted && selectionManager.GetComponent<SelectionManager>().selectedTower != upgradeTower)
        {
            tower = Instantiate(selectionManager.GetComponent<SelectionManager>().selectedTower,transform.position, transform.rotation);
            tower.name = this.name;
            tower.GetComponent<BaseTowerScript>().selectionManager = selectionManager;
            highlighted = false;
            Destroy(towerGhost);
            Destroy(gameObject);
        }
    }

}