using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankEnemy : BaseEnemyScript
{
    public override void Start()
    {
        maxHP = 500;
        base.Start();
    }
    public override void Update()
    {
        invulnTimer += Time.deltaTime;
        if (invulnTimer > 2.5f)
        {
            invulnerable = false;
        }
        PathFunction();
        if (hp <= 0)
        {
            Destroy(gameObject);
            //victory (gameover but switch text)
            manager.GetComponent<SelectionManager>().GOVText.text = "Victory!";
            manager.GetComponent<SelectionManager>().PauseGOV();
            manager.GetComponent<SelectionManager>().VictorySFX();
        }
        hpSlider.value = hp / maxHP;
        shieldSlider.value = shieldHP / shieldMaxHP;
    }
}
