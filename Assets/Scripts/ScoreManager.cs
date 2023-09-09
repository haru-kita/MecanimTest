using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance; // �V���O���g���C���X�^���X

    private int totalScore = 0; // ���v�X�R�A

    public Text scoreText; // UI��̃X�R�A�\���e�L�X�g

    private void Awake()
    {
        // �V���O���g���p�^�[���̃C���X�^���X��ݒ�
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddScore(int score)
    {
        // �X�R�A��ǉ�
        totalScore += score;
        // �X�R�A��UI�ɔ��f����
        UpdateScoreUI();
    }

    void UpdateScoreUI()
    {
        // UI��̃e�L�X�g�ɃX�R�A��\��
        scoreText.text = "Score: " + totalScore + "pt";

    }
}
