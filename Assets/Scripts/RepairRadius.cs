using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepairRadius : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Tower") && other.GetComponent<RepairTower>() == null)
        {
            other.GetComponent<MainTower>().FullHeal();
            other.GetComponent<MainTower>().leeched = false;
            other.GetComponent<MainTower>().leechTarget = false;
        }
        if (other.CompareTag("ActiveLeech")|| other.CompareTag("InactiveLeech"))
        {
            other.GetComponent<BaseEnemyScript>().hp = 0;
        }
    }
}
