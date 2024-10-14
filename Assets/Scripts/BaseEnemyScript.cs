using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseEnemyScript : MonoBehaviour
{
    public int hp;
    public int maxHP;
    public AmNode[] nodes;
    int currentNode = 0;
    public float speed;
    public float tolerance;

    public virtual void Start()
    {
        hp = maxHP;
    }

    public virtual void Update()
    {
        PathFunction();
        if(hp <= 0)
        {
            Destroy(gameObject);
        }
    }

    public virtual void PathFunction()
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
    public virtual void Damaged(int damage)
    {
        hp -= damage;
    }
}
