using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectionManager : MonoBehaviour
{
    public GameObject selectedTower, selectedTowerGhost;
    public GameObject baseGrid;
    public GameObject AttackTower, AttackGhost, ResourceTower, ResourceGhost, Upgrade, DestroyT;
    public GameObject AttackTower2, AttackGhost2;

    public GameObject pawn, shield;

    public AmNode node1, node2;
    

    public int money;

    //these switch functions should be replaced with a function that asks for a variable to switch to that tower
    public void switchAttack()
    {
        selectedTower = AttackTower;
        selectedTowerGhost = AttackGhost;
    }
    public void switchAttack2()
    {
        selectedTower = AttackTower2;
        selectedTowerGhost = AttackGhost2;
    }
    public void switchResource()
    {
        selectedTower = ResourceTower;
        selectedTowerGhost = ResourceGhost;
    }
    public void switchUpgrade()
    {
        //eventually replace with leveling up instead of replacing with a selected tower
        selectedTower = Upgrade;
        selectedTowerGhost = Upgrade;
    }
    public void switchDestroy()
    {
        selectedTower = DestroyT;
        selectedTowerGhost = DestroyT;
    }
    public void spawnPawn()
    {
        GameObject spawn;
        spawn = Instantiate(pawn, new Vector3(-2, 7, 0), transform.rotation);
        spawn.name = "Pawn";
        AmNode[] nodes = { node1, node2 };
        spawn.GetComponent<BaseEnemyScript>().nodes = nodes;

    }
    public void spawnShield()
    {
        GameObject spawn;
        spawn = Instantiate(shield, new Vector3(-2, 7, 0), transform.rotation);
        spawn.name = "Shield";
        AmNode[] nodes = { node1, node2 };
        spawn.GetComponent<BaseEnemyScript>().nodes = nodes;
    }
}
