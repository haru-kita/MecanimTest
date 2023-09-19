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
        // Titieボタンがクリックされたときの処理を設定
        titleButton.onClick.AddListener(BackGame);
        // STARTボタンがクリックされたときの処理を設定
        startButton.onClick.AddListener(StartGame);
        // Exitボタンがクリックされたときの処理を設定
        exitButton.onClick.AddListener(ExitGame);
    }

    //Titleボタンがクリックされたときの処理
    private void BackGame()
    {
        //Titleシーンに遷移
        SceneManager.LoadScene("TitleScene");
    }

    //STARTボタンがクリックされたときの処理
    private void StartGame()
    {
        //バトルシーンに遷移
        SceneManager.LoadScene("BattleScene");
    }

    //Exitボタンがクリックされたときの処理
    private void ExitGame()
    {
        //アプリを落とす
        Application.Quit();
    }

}
