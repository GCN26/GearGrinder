using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KaboomScript : MonoBehaviour
{
    public float timer;
    public AudioClip sfx;
    public AudioSource sfxSource;

    private void Start()
    {
        sfxSource = GetComponent<AudioSource>();
    }
    void Update()
    {
        if (timer == 0)
        {
            sfxSource.PlayOneShot(sfx, .5f);
        }
        timer += Time.deltaTime;
        if (timer > .15)
        {
            Destroy(gameObject);
        }
    }
}
