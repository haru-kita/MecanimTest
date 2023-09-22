using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ResultSceneManager : MonoBehaviour
{
    public Button titleButton;
    public Button startButton;
    public Button exitButton;
    public Text scoreText;

    private void Start()
    {
        // Titie�{�^�����N���b�N���ꂽ�Ƃ��̏�����ݒ�
        titleButton.onClick.AddListener(BackGame);
        // START�{�^�����N���b�N���ꂽ�Ƃ��̏�����ݒ�
        startButton.onClick.AddListener(StartGame);
        // Exit�{�^�����N���b�N���ꂽ�Ƃ��̏�����ݒ�
        exitButton.onClick.AddListener(ExitGame);

        // �X�R�A���擾���ăe�L�X�g�ɔ��f
        int score = PlayerPrefs.GetInt("LastScore", 0);
        string formattedScore = score.ToString("D4"); // 4���̃t�H�[�}�b�g�ɕϊ����ăe�L�X�g�ɕ\��
        scoreText.text = "Score: " + formattedScore + "pt";
    }

    // Title�{�^�����N���b�N���ꂽ�Ƃ��̏���
    private void BackGame()
    {
        // Title�V�[���ɑJ��
        SceneManager.LoadScene("TitleScene");
    }

    // START�{�^�����N���b�N���ꂽ�Ƃ��̏���
    private void StartGame()
    {
        // �X�R�A��ۑ�
        int score = PlayerPrefs.GetInt("LastScore", 0);
        PlayerPrefs.SetInt("LastScore", score);

        // �o�g���V�[���ɑJ��
        SceneManager.LoadScene("BattleScene");
    }

    // Exit�{�^�����N���b�N���ꂽ�Ƃ��̏���
    private void ExitGame()
    {
        // �A�v���𗎂Ƃ�
        Application.Quit();
    }
}
