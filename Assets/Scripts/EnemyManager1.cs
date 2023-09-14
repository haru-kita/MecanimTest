using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyManager1 : MonoBehaviour
{
    [SerializeField] EnemyStatusSO enemyStatusSO;
    [SerializeField] PlayerStatusSO playerStatusSO;
    public int scoreValue = 10; //この敵の得点
    public GameObject destroyEffectPrefab; // エフェクト用のプレハブ

    private int enemyHP;
    private int damage;
    private Animator anim;


    void Start()
    {
        // 敵のHPを初期化
        enemyHP = enemyStatusSO.enemyStatusList[1].EnemyHP;
        anim = GetComponent<Animator>();
    }

    // Playerに攻撃された時の関数
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("Weapon"))
        {
            damage = (int)(playerStatusSO.PlayerATTACK / 2 - enemyStatusSO.enemyStatusList[1].EnemyDEFENCE / 4);

            if (damage > 0)
            {
                Debug.Log("ヒット");
                // GetHitアニメーションを再生
                this.anim.SetTrigger("GetHit");

                // ダメージを敵のHPから減算
                enemyHP -= damage;

                if (enemyHP <= 0)
                {
                    Debug.Log("HPがゼロになった");
                    // Deathアニメーションを再生
                    this.anim.SetTrigger("Death");

                    // 敵が破壊されたときにスコアを更新
                    ScoreManager.Instance.AddScore(scoreValue);

                    // 敵を破棄
                    Destroy(this.gameObject);

                    // エフェクトを発生させる
                    if (destroyEffectPrefab != null)
                    {
                        Instantiate(destroyEffectPrefab, transform.position, Quaternion.identity);
                    }
                }
            }
        }
    }
}
