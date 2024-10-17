using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainTower : BaseTowerScript
{
    public int level = 0;
    public int hp;
    public int maxHP = 10;

    public virtual void Start()
    {
        hp = maxHP;
        level = 1;
    }
    public override void Update()
    {
        base.Update();
        if(hp <= 0)
        {
            GameObject grid;
            grid = Instantiate(selectionManager.GetComponent<SelectionManager>().baseGrid, transform.position, transform.rotation);
            grid.name = this.name;
            grid.GetComponent<BaseTowerScript>().selectionManager = selectionManager;
            highlighted = false;
            Destroy(towerGhost);
            Destroy(gameObject);
        }
    }

    public override void OnMouseOver()
    {
        if (selectionManager.GetComponent<SelectionManager>().selectedTower == destroyTower)
        {
            highlighted = true;
        }
        if (level < 3)
        {
            if (selectionManager.GetComponent<SelectionManager>().selectedTower == upgradeTower)
            {
                highlighted = true;
            }
        }
    }

    public override void OnMouseDown()
    {
        //if tower is upgrade ghost and there is enough money
        //upgrade 1 should cost 100 money
        //upgrade 2 should cost 250 money
        //these values are subject to change
        if (highlighted && selectionManager.GetComponent<SelectionManager>().selectedTower == upgradeTower)
        {
            level += 1;
            UpgradeFunction();
            highlighted = false;
            Destroy(towerGhost);
        }
        else if (highlighted && selectionManager.GetComponent<SelectionManager>().selectedTower == destroyTower)
        {
            hp = 0;
            highlighted = false;
            Destroy(towerGhost);
        }
    }
    public virtual void UpgradeFunction()
    {
        FullHeal();
    }
    public virtual void FullHeal()
    {
        hp = maxHP;
        //remove leeches
    }
}
