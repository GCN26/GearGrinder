using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class BaseTowerScript : MonoBehaviour
{
    protected bool highlighted;
    public GameObject gridManager;
    protected GameObject towerGhost = null;
    public GameObject upgradeTower;
    protected int hp = 10;

    private void OnMouseOver()
    {
        //Mouse is over tower grid space and the selection a valid placement for this tower
        highlighted = true;
    }
    private void OnMouseExit()
    {
        //Mouse is no longer over tower grid space
        highlighted = false;
    }

    private void OnMouseDown()
    {
        //Mouse is over tower grid space and the player clicks
        if (highlighted)
        {
            
        }
    }

    void Update()
    {
        //Tower Ghost shows up on valid selections
        //if grid is selected and no tower is already on that space, if click, build tower
        if (highlighted)
        {
            if (!GameObject.Find("Ghost" + this.name))
            {
                towerGhost = Instantiate(gridManager.GetComponent<SelectionManager>().selectedTowerGhost, transform.position, transform.rotation);
                towerGhost.name = "Ghost" + this.name;
            }
        }
        if (highlighted == false)
        {
            Destroy(GameObject.Find("Ghost" + this.name));
        }
        //if hp <= 0, reset to grid space
    }
}
