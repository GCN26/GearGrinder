using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class BaseTowerScript : MonoBehaviour
{
    protected bool highlighted;
    public GameObject selectionManager;
    protected GameObject towerGhost = null;
    public GameObject upgradeTower;

    public virtual void OnMouseOver()
    {
        //Mouse is over tower grid space and the selection a valid placement for this tower
        highlighted = true;
    }
    public virtual void OnMouseExit()
    {
        //Mouse is no longer over tower grid space
        highlighted = false;
    }

    public virtual void OnMouseDown()
    {
        //Mouse is over tower grid space and the player clicks
        if (highlighted)
        {
            
        }
    }

    public virtual void Update()
    {
        //Tower Ghost shows up on valid selections
        //if grid is selected and no tower is already on that space and there is enough money, if click, build tower
        if (highlighted)
        {
            if (!GameObject.Find("Ghost" + this.name))
            {
                towerGhost = Instantiate(selectionManager.GetComponent<SelectionManager>().selectedTowerGhost, transform.position, transform.rotation);
                towerGhost.name = "Ghost" + this.name;
            }
        }
        if (highlighted == false)
        {
            Destroy(GameObject.Find("Ghost" + this.name));
        }
    }
}
