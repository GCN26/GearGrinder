using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathNodeScript : MonoBehaviour
{
    //Rework into basic enemy script with hp
    public AmNode[] nodes;
    int currentNode = 0;
    public float speed;
    public float tolerance;

    void Update()
    {
        Vector3 targetPosition = nodes[currentNode].transform.position;
        Vector3 direction = targetPosition - this.transform.position;
        direction = direction.normalized;

        this.transform.position += direction * speed * Time.deltaTime;

        if (Vector3.Distance(targetPosition, this.transform.position) < tolerance)
        {
            currentNode = currentNode + 1;
            currentNode = currentNode % nodes.Length;
        }
    }
}
