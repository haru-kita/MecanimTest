using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public float gameTime = 120f; // �Q�[���̎���
    public Text timeText; // �c�莞�ԃI�u�W�F�N�g�̎Q��
    public AudioSource whistleAudioSource; // �I�[�f�B�I�\�[�X�������Ɋ��蓖�Ă܂�

    private float currentTime = 0.0f;
    private bool gameIsOver = false;
    private int currentScore = 0;


    void Update()
    {
        if (gameTime > 0)
        {
            gameTime -= Time.deltaTime;
            UpdateTimeUI();
            Debug.Log("Remaining Time: " + gameTime);
        }

        if (!gameIsOver)
        {
            currentTime += Time.deltaTime;
            if (currentTime >= gameTime)
            {
                EndGame();
            }
        }

    }

    void UpdateTimeUI()
    {
        //Text�I�u�W�F�N�g�Ɏc�莞�Ԃ�\������
        timeText.text = "�c�莞��: " + Mathf.Max(0, gameTime).ToString("F3"); // F1�͏����_�ȉ�1���܂ŕ\������t�H�[�}�b�g
    }

    void EndGame()
    {
        gameIsOver = true;

        // �z�C�b�X���̌��ʉ����Đ�
        whistleAudioSource.Play();

        // ���_��ǉ�
        ScoreManager.Instance.AddScore(currentScore);

        // ���_��ۑ�
        SaveScore(currentScore);


        // ���̌�̏���
        SceneManager.LoadScene("ResultScene"); // ���U���g�V�[���ɑJ��
    }

    void SaveScore(int score)
    {
        // ���_��ۑ����鏈���������ɒǉ�
        PlayerPrefs.SetInt("LastScore", score);
        // ���̕ۑ����@�i�f�[�^�x�[�X�Ȃǁj���g�p���邱�Ƃ��ł��܂�
    }
}
