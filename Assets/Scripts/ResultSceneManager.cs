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
        // Titieボタンがクリックされたときの処理を設定
        titleButton.onClick.AddListener(BackGame);
        // STARTボタンがクリックされたときの処理を設定
        startButton.onClick.AddListener(StartGame);
        // Exitボタンがクリックされたときの処理を設定
        exitButton.onClick.AddListener(ExitGame);

        // スコアを取得してテキストに反映
        int score = PlayerPrefs.GetInt("LastScore", 0);
        string formattedScore = score.ToString("D4"); // 4桁のフォーマットに変換してテキストに表示
        scoreText.text = "Score: " + formattedScore + "pt";
    }

    // Titleボタンがクリックされたときの処理
    private void BackGame()
    {
        // Titleシーンに遷移
        SceneManager.LoadScene("TitleScene");
    }

    // STARTボタンがクリックされたときの処理
    private void StartGame()
    {
        // スコアを保存
        int score = PlayerPrefs.GetInt("LastScore", 0);
        PlayerPrefs.SetInt("LastScore", score);

        // バトルシーンに遷移
        SceneManager.LoadScene("BattleScene");
    }

    // Exitボタンがクリックされたときの処理
    private void ExitGame()
    {
        // アプリを落とす
        Application.Quit();
    }
}
