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
    public int currentNode = 0;
    public float speed;
    public float tolerance;

    public GameObject manager;

    public float invulnTimer;
    public bool invulnerable;

    public Sprite spr0;
    public Sprite spr90;
    public Sprite spr180;
    public float rotateTo;

    public GameObject boom;

    public virtual void Start()
    {
        hp = maxHP;
        invulnTimer = 0;
        invulnerable = true;
    }

    public virtual void Update()
    {
        invulnTimer += Time.deltaTime;
        if(invulnTimer > 2.5f)
        {
            invulnerable = false;
        }
        PathFunction();
        if(hp <= 0)
        {
            GameObject kaboom = Instantiate(boom);
            kaboom.transform.localScale = this.transform.localScale;
            kaboom.transform.position = this.transform.position;
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
            if (rotateTo == 0) enemyObject.GetComponent<SpriteRenderer>().sprite = spr0;
            else if (rotateTo == 90) enemyObject.GetComponent<SpriteRenderer>().sprite = spr90;
            else if (rotateTo == 180) enemyObject.GetComponent<SpriteRenderer>().sprite = spr180;
        }
    }
    public virtual void Damaged(float damage)
    {
        if (invulnerable == false)
        {
            hp -= damage;
        }
    }
    
}
