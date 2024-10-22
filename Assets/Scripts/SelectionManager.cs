using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SelectionManager : MonoBehaviour
{
    public GameObject selectedTower, selectedTowerGhost;
    public int selectedCost;
    public GameObject baseGrid;

    public GameObject pawn, shield, leech, tank;

    public AmNode[] nodes = { };
    public GameObject[] hpDisplay = { };
    public TextMeshProUGUI moneyCounter;

    public int hp;
    
    public int money;

    public float spawnTimer;
    public float spawnTarget;
    public float increaseTimer;
    public float increaseTarget;
    private GameObject toSpawn;
    public bool spawnBool = false;
    public int i = 0;

    public void Update()
    {
        moneyCounter.text = "$" + money;
        if(spawnBool == true)
        {
            spawnTimer += Time.deltaTime;
            if (spawnTimer >= spawnTarget)
            {
                i++;
                if (i != 45)
                {
                    if (i % 5 == 0 && i != 0 && i < 25) spawnTarget -= .25f;
                    Debug.Log(i);
                    var randE = Random.Range(1, 8);
                    if (randE >= 1 && randE <= 4) toSpawn = pawn;
                    else if (randE >= 5 && randE <= 6) toSpawn = shield;
                    else if (randE == 7) toSpawn = leech;
                }
                else
                {
                    toSpawn = tank;
                    spawnBool = false;
                    spawnTarget = 2.5f;
                }
                spawnEnemy(toSpawn);
                spawnTimer = 0;


            }
        }
    }

    public void switchTower(GameObject tower)
    {
        selectedTower = tower;
    }
    public void switchGhost(GameObject ghost)
    {
        selectedTowerGhost = ghost;
    }
    public void switchCost(int cost)
    {
        selectedCost = cost;
    }
    public bool spend()
    {
        if (money - selectedCost >= 0)
        {
            money -= selectedCost;
            return true;
        }
        else
        {
            return false;
        }
    }
    public void spawnEnemy(GameObject enemy)
    {
        GameObject spawn;
        spawn = Instantiate(enemy, new Vector3(-4.75f, 5.68f, 0), transform.rotation);
        if(enemy == pawn) spawn.name = "Pawn";
        else if (enemy == shield) spawn.name = "Shield";
        else if (enemy == leech) spawn.name = "Leech";
        else if (enemy == tank) spawn.name = "Tank";
        spawn.GetComponent<BaseEnemyScript>().nodes = nodes;
    }

    
    public void startSpawn()
    {
        spawnBool = true;
    }
}
