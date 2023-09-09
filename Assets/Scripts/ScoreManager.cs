using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance; // シングルトンインスタンス

    private int totalScore = 0; // 合計スコア

    public Text scoreText; // UI上のスコア表示テキスト

    private void Awake()
    {
        // シングルトンパターンのインスタンスを設定
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
        // スコアを追加
        totalScore += score;
        // スコアをUIに反映する
        UpdateScoreUI();
    }

    void UpdateScoreUI()
    {
        // UI上のテキストにスコアを表示
        scoreText.text = "Score: " + totalScore + "pt";

    }
}
