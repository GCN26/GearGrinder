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
        if (selectionManager.GetComponent<SelectionManager>().selectedTower != upgradeTower && selectionManager.GetComponent<SelectionManager>().selectedTower != destroyTower)
        {
            highlighted = true;
        }
    }

    public override void OnMouseDown()
    {
        //if tower is attack, resource, or maintenance and there is enough money
        //no upgrades
        if (highlighted && selectionManager.GetComponent<SelectionManager>().selectedTower != upgradeTower && highlighted && selectionManager.GetComponent<SelectionManager>().selectedTower != destroyTower)
        {
            tower = Instantiate(selectionManager.GetComponent<SelectionManager>().selectedTower,transform.position, transform.rotation);
            tower.name = this.name;
            tower.transform.localScale = this.transform.localScale;
            tower.GetComponent<BaseTowerScript>().selectionManager = selectionManager;
            highlighted = false;
            Destroy(towerGhost);
            Destroy(gameObject);
        }
    }

}