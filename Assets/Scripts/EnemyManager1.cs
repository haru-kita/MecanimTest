using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyManager1 : MonoBehaviour
{
    [SerializeField] EnemyStatusSO enemyStatusSO;
    [SerializeField] PlayerStatusSO playerStatusSO;
    public int scoreValue = 10; // この敵の得点
    public GameObject destroyEffectPrefab; // 消滅エフェクト用
    public GameObject hitEffectPrefab; // ヒットエフェクト用

    private int enemyHP;
    private int damage;
    private Animator anim;

    // オーディオ用の変数
    private AudioSource audioSource;
    public AudioClip sound;

    void Start()
    {
        // 敵のHPを初期化
        enemyHP = enemyStatusSO.enemyStatusList[1].EnemyHP;
        anim = GetComponent<Animator>();

        // オーディオ（AudioSourceコンポーネント）を取得
        audioSource = GetComponent<AudioSource>();
    }

    // Playerに攻撃された時の関数
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("Weapon"))
        {
            damage = (int)(playerStatusSO.PlayerATTACK / 2 - enemyStatusSO.enemyStatusList[1].EnemyDEFENCE / 4);

            if (damage > 0)
            {
                Debug.Log("パンプキンマンにヒット");
                // GetHitアニメーションを再生
                this.anim.SetTrigger("GetHit");

                // ダメージを敵のHPから減算
                enemyHP -= damage;

                if (enemyHP <= 0)
                {

                    // Deathアニメーションを再生
                    this.anim.SetTrigger("Death");

                    // 敵が破壊されたときにスコアを更新
                    ScoreManager.Instance.AddScore(scoreValue);

                    // オーディオを再生
                    AudioSource.PlayClipAtPoint(sound, transform.position);

                    // ヒットエフェクトを発生させる
                    Debug.Log("ヒットエフェクト再生中");
                    if (hitEffectPrefab != null)
                    {
                        Instantiate(hitEffectPrefab, transform.position, Quaternion.identity);
                    }

                    // 敵を破棄
                    Destroy(this.gameObject);

                    // 消滅エフェクトを発生させる
                    if (destroyEffectPrefab != null)
                    {
                        Instantiate(destroyEffectPrefab, transform.position, Quaternion.identity);
                    }
                }
            }
        }
    }
}
