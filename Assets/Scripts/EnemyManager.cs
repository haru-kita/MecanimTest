using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyManager : MonoBehaviour
{
    [SerializeField] EnemyStatusSO enemyStatusSO;
    [SerializeField] PlayerStatusSO playerStatusSO;

    private int currentHP;

    // Start is called before the first frame update
    void Start()
    {
        currentHP = enemyStatusSO.enemyStatusList[0].HP;

    }

    // Update is called once per frame
    void Update()
    {

    }

    //PlayerÇ…çUåÇÇ≥ÇÍÇΩéûÇÃä÷êî
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("Weapon"))
        {
            currentHP = currentHP - playerStatusSO.ATTACK;
        }
    }
}