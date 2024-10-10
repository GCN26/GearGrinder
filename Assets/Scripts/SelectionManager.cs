using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionManager : MonoBehaviour
{
    public GameObject selectedTower;

    public GameObject towerA, towerB;

    public void switchTower()
    {
        selectedTower = towerB;
    }
}
