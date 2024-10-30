using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerDestroySound : MonoBehaviour
{
    public AudioClip destroySFX;
    public AudioSource sound;

    public float timer;
    void Start()
    {
        sound = GetComponent<AudioSource>();
        sound.PlayOneShot(destroySFX, 0.75f);
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer > 1)
        {
            Destroy(gameObject);
        }
    }
}
