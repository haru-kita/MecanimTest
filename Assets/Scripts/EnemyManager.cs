using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class EnemyManager : MonoBehaviour
{
    [SerializeField] EnemyStatusSO enemyStatusSO;
    [SerializeField] PlayerStatusSO playerStatusSO;
    public int scoreValue = 10; //この敵の得点

    private int enemyHP;
    private int damage;
    private Animator anim;


    void Start()
    {
        enemyHP = enemyStatusSO.enemyStatusList[0].EnemyHP;

        this.anim = GetComponent<Animator>();

    }


    void Update()
    {


    }

    //Playerに攻撃された時の関数
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("Weapon"))
        {
            damage = (int)(playerStatusSO.PlayerATTACK / 2 - enemyStatusSO.enemyStatusList[0].EnemyDEFENCE / 4);
            Debug.Log("damage");

            if (damage > 0)
            {
                Debug.Log("HP引かれた値出るはず");
                enemyHP = enemyHP - damage;
            }

            if (enemyHP < 0)
            {
                // 敵が破壊されたときにスコアを更新
                ScoreManager.Instance.AddScore(scoreValue);
                Destroy(this.gameObject);
            }
        }
    }
}