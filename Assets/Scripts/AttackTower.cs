using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackTower : MainTower
{
    public float attackTimer = 0;
    public float attackTimerTarget = 1.5f;
    public List<GameObject> targets;
    public GameObject searchRadius;

    private void Update()
    {
        attackTimer += Time.deltaTime;

        if(attackTimer >= attackTimerTarget)
        {
            attackTimer = 0;
            Destroy(targets[0]);
        }

        for(int i = 0;i< targets.Count; i++)
        {
            if (targets[i] == null)
            {
                targets.RemoveAt(i);
            }
        }

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
    private void OnDestroy()
    {
        targets = null;
    }
}
