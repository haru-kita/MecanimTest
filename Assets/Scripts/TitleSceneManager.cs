using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitleSceneManager : MonoBehaviour
{
    public Button startButton; // �^�C�g����ʂ�START�{�^����Inspector�Ŋ֘A�t��

    private void Start()
    {
        // START�{�^�����N���b�N���ꂽ�Ƃ��̏�����ݒ�
        startButton.onClick.AddListener(StartGame);
    }

    // START�{�^�����N���b�N���ꂽ�Ƃ��̏���
    private void StartGame()
    {
        // �o�g���V�[���ɑJ��
        SceneManager.LoadScene("BattleScene");
    }
}
