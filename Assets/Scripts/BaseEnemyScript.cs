using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class BaseEnemyScript : MonoBehaviour
{
    public float hp;
    public float maxHP;
    public float shieldHP;
    public float shieldMaxHP;

    public Slider hpSlider;
    public Slider shieldSlider;

    public GameObject enemyObject;

    public AmNode[] nodes;
    int currentNode = 0;
    public float speed;
    public float tolerance;

    public GameObject manager;

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
        hpSlider.value = hp / maxHP;
        shieldSlider.value = shieldHP / shieldMaxHP;
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
    public virtual void Damaged(float damage)
    {
        hp -= damage;
    }
    
}
