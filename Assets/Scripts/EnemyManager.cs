using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class EnemyManager : MonoBehaviour
{
    [SerializeField] EnemyStatusSO enemyStatusSO;
    [SerializeField] PlayerStatusSO playerStatusSO;
    public int scoreValue = 10; //���̓G�̓��_
    public GameObject destroyEffectPrefab; // �G�t�F�N�g�p�̃v���n�u

    private int enemyHP;
    private int damage;


    void Start()
    {
        enemyHP = enemyStatusSO.enemyStatusList[0].EnemyHP;

    }


    void Update()
    {

    }

    //Player�ɍU�����ꂽ���̊֐�
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("Weapon"))
        {
            damage = (int)(playerStatusSO.PlayerATTACK / 2 - enemyStatusSO.enemyStatusList[0].EnemyDEFENCE / 4);
            Debug.Log("damage");

            if (damage > 0)
            {
                Debug.Log("HP�����ꂽ�l�o��͂�");
                enemyHP = enemyHP - damage;
            }

            if (enemyHP < 0)
            {
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