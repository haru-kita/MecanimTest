using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyManager : MonoBehaviour
{
    [SerializeField] EnemyStatusSO enemyStatusSO;
    [SerializeField] PlayerStatusSO playerStatusSO;

    private int enemyHP;
    private int damage;


    void Start()
    {
        enemyHP = enemyStatusSO.enemyStatusList[0].HP;

    }


    void Update()
    {
        Debug.Log(enemyHP);

        if (enemyHPÅ@< 0)
        {
            Destroy(this.gameObject);
        }
    }

    //PlayerÇ…çUåÇÇ≥ÇÍÇΩéûÇÃä÷êî
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("Weapon"))
        {
            damage = (int)(playerStatusSO.ATTACK / 2 - enemyStatusSO.enemyStatusList[0].DEFENCE / 4);

            if (damage > 0)
            {
                enemyHP = enemyHP - damage;
            }

        }
    }
}