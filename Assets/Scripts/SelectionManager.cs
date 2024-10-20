using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectionManager : MonoBehaviour
{
    public GameObject selectedTower, selectedTowerGhost;
    public GameObject baseGrid;

    public GameObject pawn, shield, leech, tank;

    public AmNode node1, node2;
    

    public int money;

    public void switchTower(GameObject tower)
    {
        selectedTower = tower;
    }
    public void switchGhost(GameObject ghost)
    {
        selectedTowerGhost = ghost;
    }
    public void spawnEnemy(GameObject enemy)
    {
        GameObject spawn;
        spawn = Instantiate(enemy, new Vector3(-2, 7, 0), transform.rotation);
        if(enemy == pawn) spawn.name = "Pawn";
        else if (enemy == shield) spawn.name = "Shield";
        else if (enemy == leech) spawn.name = "Leech";
        else if (enemy == tank) spawn.name = "Tank";
        AmNode[] nodes = { node1, node2 };
        spawn.GetComponent<BaseEnemyScript>().nodes = nodes;
    }
}
