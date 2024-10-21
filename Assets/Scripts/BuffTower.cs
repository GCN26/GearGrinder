using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class BuffTower : MainTower
{
    public List<GameObject> towers;
    public float dieTimer = 0;
    public float dieTarget = 1;
    public GameObject buffCircle;

    public override void Update()
    {
        base.Update();

        if (leeched != true)
        {
            dieTimer += Time.deltaTime;
            buffCircle.SetActive(true);

            if (dieTimer >= dieTarget)
            {
                dieTimer = 0;
                hp -= 1;
            }

            for (int i = 0; i < towers.Count; i++)
            {
                if (towers[i] == null)
                {
                    towers.RemoveAt(i);
                }
            }
        }
        else
        {
            buffCircle.SetActive(false);
        }
    }
}
