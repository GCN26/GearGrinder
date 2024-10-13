using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackTowerRadius2 : MonoBehaviour
{
    public GameObject towerParent;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            towerParent.GetComponent<AttackTower2>().targets.Add(other.gameObject);
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Enemy") && other != null)
        {
            towerParent.GetComponent<AttackTower2>().targets.Remove(other.gameObject);
        }
    }
}
