using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public GameObject manager;
    public AudioClip hurtSFX;
    public AudioSource sfxSource;
    public void Start()
    {
        sfxSource = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        //if juggernaut, automatically set hp to 0
        //else, lower hp by 1
        if (manager.GetComponent<SelectionManager>().hp > 0)
        {
            sfxSource.PlayOneShot(hurtSFX, .5f);
            if (other.name == "Tank")
            {
                for (int i = manager.GetComponent<SelectionManager>().hp; i > 0; i--)
                {
                    Destroy(manager.GetComponent<SelectionManager>().hpDisplay[i-1]);
                }
                manager.GetComponent<SelectionManager>().hp = 0;

                Destroy(other.gameObject);
            }
            else if (other.CompareTag("Enemy"))
            {
                manager.GetComponent<SelectionManager>().hp -= 1;
                Destroy(manager.GetComponent<SelectionManager>().hpDisplay[manager.GetComponent<SelectionManager>().hp]);
                Destroy(other.gameObject);
            }
            
        }
    }
}
