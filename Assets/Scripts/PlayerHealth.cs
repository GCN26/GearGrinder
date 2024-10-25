using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public GameObject manager;
    private void OnTriggerEnter2D(Collider2D other)
    {
        //if juggernaut, automatically set hp to 0
        //else, lower hp by 1
        if (manager.GetComponent<SelectionManager>().hp > 0)
        {
            if (other.CompareTag("Enemy"))
            {
                manager.GetComponent<SelectionManager>().hp -= 1;
                Destroy(manager.GetComponent<SelectionManager>().hpDisplay[manager.GetComponent<SelectionManager>().hp]);
                Destroy(other.gameObject);
            }
        }
    }
}
