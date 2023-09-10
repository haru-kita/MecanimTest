using UnityEngine;
using UnityEngine.UI;

public class ResultScoreDisplay : MonoBehaviour
{
    public Text scoreText; // �X�R�A��\�����邽�߂�UI�e�L�X�g

    void Start()
    {
        // �X�R�A���擾���ăe�L�X�g�ɔ��f
        int score = PlayerPrefs.GetInt("LastScore", 0); // �X�R�A�����[�h�i�O�̃V�[������󂯌p�������̂Ɖ���j
        string formattedScore = score.ToString("D4"); // 4���̃t�H�[�}�b�g�ɕϊ����ăe�L�X�g�ɕ\��
        scoreText.text = "Score: " + formattedScore + "pt";
    }
}
