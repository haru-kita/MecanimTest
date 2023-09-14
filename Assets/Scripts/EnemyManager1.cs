using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyManager1 : MonoBehaviour
{
    [SerializeField] EnemyStatusSO enemyStatusSO;
    [SerializeField] PlayerStatusSO playerStatusSO;
    public int scoreValue = 10; //���̓G�̓��_
    public GameObject destroyEffectPrefab; // �G�t�F�N�g�p�̃v���n�u

    private int enemyHP;
    private int damage;
    private Animator anim;


    void Start()
    {
        // �G��HP��������
        enemyHP = enemyStatusSO.enemyStatusList[1].EnemyHP;
        anim = GetComponent<Animator>();
    }

    // Player�ɍU�����ꂽ���̊֐�
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("Weapon"))
        {
            damage = (int)(playerStatusSO.PlayerATTACK / 2 - enemyStatusSO.enemyStatusList[1].EnemyDEFENCE / 4);

            if (damage > 0)
            {
                Debug.Log("�q�b�g");
                // GetHit�A�j���[�V�������Đ�
                this.anim.SetTrigger("GetHit");

                // �_���[�W��G��HP���猸�Z
                enemyHP -= damage;

                if (enemyHP <= 0)
                {
                    Debug.Log("HP���[���ɂȂ���");
                    // Death�A�j���[�V�������Đ�
                    this.anim.SetTrigger("Death");

                    // �G���j�󂳂ꂽ�Ƃ��ɃX�R�A���X�V
                    ScoreManager.Instance.AddScore(scoreValue);

                    // �G��j��
                    Destroy(this.gameObject);

                    // �G�t�F�N�g�𔭐�������
                    if (destroyEffectPrefab != null)
                    {
                        Instantiate(destroyEffectPrefab, transform.position, Quaternion.identity);
                    }
                }
            }
        }
    }
}
