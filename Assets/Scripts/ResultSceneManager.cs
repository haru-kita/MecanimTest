using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ResultSceneManager : MonoBehaviour
{
    public Button titleButton;
    public Button startButton;
    public Button exitButton;

    private void Start()
    {
        // Titie�{�^�����N���b�N���ꂽ�Ƃ��̏�����ݒ�
        titleButton.onClick.AddListener(BackGame);
        // START�{�^�����N���b�N���ꂽ�Ƃ��̏�����ݒ�
        startButton.onClick.AddListener(StartGame);
        // Exit�{�^�����N���b�N���ꂽ�Ƃ��̏�����ݒ�
        exitButton.onClick.AddListener(ExitGame);
    }

    //Title�{�^�����N���b�N���ꂽ�Ƃ��̏���
    private void BackGame()
    {
        //Title�V�[���ɑJ��
        SceneManager.LoadScene("TitleScene");
    }

    //START�{�^�����N���b�N���ꂽ�Ƃ��̏���
    private void StartGame()
    {
        //�o�g���V�[���ɑJ��
        SceneManager.LoadScene("BattleScene");
    }

    //Exit�{�^�����N���b�N���ꂽ�Ƃ��̏���
    private void ExitGame()
    {
        //�A�v���𗎂Ƃ�
        Application.Quit();
    }

}
