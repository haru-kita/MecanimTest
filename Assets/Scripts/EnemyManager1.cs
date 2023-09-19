using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyManager1 : MonoBehaviour
{
    [SerializeField] EnemyStatusSO enemyStatusSO;
    [SerializeField] PlayerStatusSO playerStatusSO;
    public int scoreValue = 10; // ���̓G�̓��_
    public GameObject destroyEffectPrefab; // ���ŃG�t�F�N�g�p
    public GameObject hitEffectPrefab; // �q�b�g�G�t�F�N�g�p

    private int enemyHP;
    private int damage;
    private Animator anim;

    // �I�[�f�B�I�p�̕ϐ�
    private AudioSource audioSource;
    public AudioClip sound;

    void Start()
    {
        // �G��HP��������
        enemyHP = enemyStatusSO.enemyStatusList[1].EnemyHP;
        anim = GetComponent<Animator>();

        // �I�[�f�B�I�iAudioSource�R���|�[�l���g�j���擾
        audioSource = GetComponent<AudioSource>();
    }

    // Player�ɍU�����ꂽ���̊֐�
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("Weapon"))
        {
            damage = (int)(playerStatusSO.PlayerATTACK / 2 - enemyStatusSO.enemyStatusList[1].EnemyDEFENCE / 4);

            if (damage > 0)
            {
                Debug.Log("�p���v�L���}���Ƀq�b�g");
                // GetHit�A�j���[�V�������Đ�
                this.anim.SetTrigger("GetHit");

                // �_���[�W��G��HP���猸�Z
                enemyHP -= damage;

                if (enemyHP <= 0)
                {

                    // Death�A�j���[�V�������Đ�
                    this.anim.SetTrigger("Death");

                    // �G���j�󂳂ꂽ�Ƃ��ɃX�R�A���X�V
                    ScoreManager.Instance.AddScore(scoreValue);

                    // �I�[�f�B�I���Đ�
                    AudioSource.PlayClipAtPoint(sound, transform.position);

                    // �q�b�g�G�t�F�N�g�𔭐�������
                    Debug.Log("�q�b�g�G�t�F�N�g�Đ���");
                    if (hitEffectPrefab != null)
                    {
                        Instantiate(hitEffectPrefab, transform.position, Quaternion.identity);
                    }

                    // �G��j��
                    Destroy(this.gameObject);

                    // ���ŃG�t�F�N�g�𔭐�������
                    if (destroyEffectPrefab != null)
                    {
                        Instantiate(destroyEffectPrefab, transform.position, Quaternion.identity);
                    }
                }
            }
        }
    }
}
