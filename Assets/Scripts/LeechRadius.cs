using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeechRadius : MonoBehaviour
{
    public GameObject leech;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (leech.GetComponent<LeechEnemy>().jumpSelect == false)
        {
            if (other.CompareTag("Tower") && other.GetComponent<MainTower>().leeched == false && other.GetComponent<MainTower>().leechTarget == false)
            {
                leech.GetComponent<LeechEnemy>().towers.Add(other.gameObject);
                if (other.GetComponent<ResourceTower>() || other.GetComponent<BuffTower>())
                {
                    leech.GetComponent<LeechEnemy>().preferedTowers.Add(other.gameObject);
                }
            }
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Tower"))
        {
            leech.GetComponent<LeechEnemy>().towers.Remove(other.gameObject);
            if (other.GetComponent<ResourceTower>() || other.GetComponent<BuffTower>())
            {
                leech.GetComponent<LeechEnemy>().preferedTowers.Remove(other.gameObject);
            }
        }
    }
}
