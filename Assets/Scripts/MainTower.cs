using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainTower : BaseTowerScript
{
    public int level = 0;
    public float hp;
    public float maxHP = 10;

    public bool buffed;
    public bool leeched = false;
    public bool leechTarget = false;

    public Slider hpSlider;

    public GameObject towerTop;

    public bool highlighted2;
    public float z2;

    public GameObject upgradeObj;
    public Sprite upgrade1;
    public Sprite upgrade2;

    public virtual void Start()
    {
        hp = maxHP;
        level = 1;
        z2 = this.transform.position.z -2;
    }
    public override void Update()
    {
        base.Update();
        if(hp <= 0)
        {
            GameObject grid;
            grid = Instantiate(selectionManager.GetComponent<SelectionManager>().baseGrid, transform.position, transform.rotation);
            grid.transform.localScale = this.transform.localScale;
            grid.name = this.name;
            grid.GetComponent<BaseTowerScript>().selectionManager = selectionManager;
            highlighted = false;
            Destroy(towerGhost);
            Destroy(gameObject);
        }
        hpSlider.value = hp / maxHP;
        if (leeched)
        {
            //stop all other functions, disallow upgrades and destruction, and sap hp at 1 per second
            hp -= Time.deltaTime;
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
        highlighted2 = true;
        transform.position = new Vector3(transform.position.x, transform.position.y, z2);
    }
    public override void OnMouseExit()
    {
        base.OnMouseExit();
        highlighted2 = false;
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.y*.1f);
    }

    public override void OnMouseDown()
    {
        //if tower is upgrade ghost and there is enough money
        //upgrade 1 should cost 100 money
        //upgrade 2 should cost 250 money
        //these values are subject to change
        if (highlighted && selectionManager.GetComponent<SelectionManager>().selectedTower == upgradeTower)
        {
            if (selectionManager.GetComponent<SelectionManager>().spend())
            {
                level += 1;
                UpgradeFunction();
                highlighted = false;
                Destroy(towerGhost);
            }
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
