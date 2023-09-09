using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class EnemyManager : MonoBehaviour
{
    [SerializeField] EnemyStatusSO enemyStatusSO;
    [SerializeField] PlayerStatusSO playerStatusSO;

    private int enemyHP;
    private int damage;
    private GameObject scoreText;
    private int score = 00000;
    private Animator anim;


    void Start()
    {
        enemyHP = enemyStatusSO.enemyStatusList[0].EnemyHP;

        this.scoreText = GameObject.Find("ScoreText");
        this.scoreText.GetComponent<Text>().text = "得点：" + score;

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
                // スコアを加算して表示
                this.score += 500;
                this.scoreText.GetComponent<Text>().text = "得点：" + score;

                Destroy(this.gameObject);
            }
        }
    }
}