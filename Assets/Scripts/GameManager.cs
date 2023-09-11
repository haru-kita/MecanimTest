using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public float gameTime; // �Q�[���̎���
    public Text timeText; // �c�莞�ԃI�u�W�F�N�g�̎Q��
    public AudioSource whistleAudioSource; // �I�[�f�B�I�\�[�X�������Ɋ��蓖�Ă܂�

    private bool gameIsOver = false;
    private int currentScore = 0;


    void Update()
    {

        if (gameTime >= 0)
        {
            UpdateTimeUI();
        }

        if ( gameTime <= 0 && gameIsOver == false)
        {
            EndGame();
            whistleAudioSource.Play(); //�z�C�b�X�����Đ�
        }

        if (gameTime <= -1)
        {
            SceneManager.LoadScene("ResultScene"); // ���U���g�V�[���ɑJ��
        }

        gameTime -= Time.deltaTime;

    }

    void UpdateTimeUI()
    {
        //Text�I�u�W�F�N�g�Ɏc�莞�Ԃ�\������
        timeText.text = "�c�莞��: " + Mathf.Max(0, gameTime).ToString("F3"); // F1�͏����_�ȉ�1���܂ŕ\������t�H�[�}�b�g
    }

    void EndGame()
    {
        gameIsOver = true;


        // ���_��ǉ�
        ScoreManager.Instance.AddScore(currentScore);

        // ���_��ۑ�
        SaveScore(currentScore);

    }

    void SaveScore(int score)
    {
        // ���_��ۑ����鏈���������ɒǉ�
        PlayerPrefs.SetInt("LastScore", ScoreManager.Instance.totalScore);

    }
}
