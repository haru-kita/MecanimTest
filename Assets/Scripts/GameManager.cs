using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public float gameTime; // ゲームの時間
    public Text timeText; // 残り時間オブジェクトの参照
    public AudioSource whistleAudioSource; // オーディオソースをここに割り当てます

    private float currentTime = 0.0f;
    private bool gameIsOver = false;
    private int currentScore = 0;


    // GameManagerのAwakeメソッドを追加
    private void Awake()
    {
        // GameManagerにAudioSourceがアタッチされていることを確認
        if (whistleAudioSource == null)
        {
            Debug.LogError("AudioSourceがアタッチされていません。GameManagerにAudioSourceをアタッチしてください。");
        }
    }

    void Update()
    {

        if (gameTime >= 0)
        {
            UpdateTimeUI();
        }

        if ( gameTime <= 0 && gameIsOver == false)
        {
            EndGame();
            whistleAudioSource.Play(); //ホイッスル音再生
        }

        if (gameTime <= -1)
        {
            SceneManager.LoadScene("ResultScene"); // リザルトシーンに遷移
        }

        gameTime -= Time.deltaTime;

    }

    void UpdateTimeUI()
    {
        //Textオブジェクトに残り時間を表示する
        timeText.text = "残り時間: " + Mathf.Max(0, gameTime).ToString("F3"); // F1は小数点以下1桁まで表示するフォーマット
    }

    void EndGame()
    {
        gameIsOver = true;


        // 得点を追加
        ScoreManager.Instance.AddScore(currentScore);

        // 得点を保存
        SaveScore(currentScore);

    }

    void SaveScore(int score)
    {
        // 得点を保存する処理をここに追加
        PlayerPrefs.SetInt("LastScore", ScoreManager.Instance.totalScore);
        // 他の保存方法（データベースなど）を使用することもできます
    }
}
