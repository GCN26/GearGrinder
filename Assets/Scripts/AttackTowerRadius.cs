using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class AttackTowerRadius : MonoBehaviour
{
    public GameObject towerParent;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            towerParent.GetComponent<AttackTower>().targets.Add(other.gameObject);
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Enemy") && other != null)
        {
            towerParent.GetComponent<AttackTower>().targets.Remove(other.gameObject);
        }
    }
}
