using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffTowerRadius : MonoBehaviour
{
    public GameObject towerParent;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Tower")&& other.GetComponent<BuffTower>() == null)
        {
            other.GetComponent<MainTower>().buffed = true;
            towerParent.GetComponent<BuffTower>().towers.Add(other.gameObject);
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Tower") && other.GetComponent<BuffTower>() == null && other != null)
        {
            other.GetComponent<MainTower>().buffed = false;
            towerParent.GetComponent<BuffTower>().towers.Remove(other.gameObject);
        }
    }
}
