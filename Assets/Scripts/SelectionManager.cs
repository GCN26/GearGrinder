using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SelectionManager : MonoBehaviour
{
    public GameObject selectedTower, selectedTowerGhost;
    public GameObject baseGrid;

    public GameObject pawn, shield, leech, tank;

    public AmNode[] nodes = { };
    public TextMeshProUGUI moneyCounter;
    

    public int money;

    public void Update()
    {
        moneyCounter.text = "$" + money;
    }

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
        spawn.GetComponent<BaseEnemyScript>().nodes = nodes;
    }
}
