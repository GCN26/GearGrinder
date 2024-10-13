using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionManager : MonoBehaviour
{
    public GameObject selectedTower, selectedTowerGhost;

    public GameObject towerA, towerB, towerAGhost, towerBGhost, towerUpgrade;

    public int money;

    public void switchAttack()
    {
        selectedTower = towerA;
        selectedTowerGhost = towerAGhost;
    }
    public void switchResource()
    {
        selectedTower = towerB;
        selectedTowerGhost = towerBGhost;
    }
    public void switchUpgrade()
    {
        //eventually replace with leveling up instead of replacing with a selected tower
        selectedTower = towerUpgrade;
        selectedTowerGhost = towerUpgrade;
    }
}
