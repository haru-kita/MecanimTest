using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitleSceneManager : MonoBehaviour
{
    public Button startButton; // タイトル画面のSTARTボタンをInspectorで関連付け

    private void Start()
    {
        // STARTボタンがクリックされたときの処理を設定
        startButton.onClick.AddListener(StartGame);
    }

    // STARTボタンがクリックされたときの処理
    private void StartGame()
    {
        // バトルシーンに遷移
        SceneManager.LoadScene("BattleScene");
    }
}
