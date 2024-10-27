using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmNode : MonoBehaviour
{
    public float touchRot;
    

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy") || other.CompareTag("InactiveLeech"))
        {
            other.GetComponent<BaseEnemyScript>().rotateTo = touchRot;
        }
    }
}
