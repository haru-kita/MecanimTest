using UnityEngine;
using UnityEngine.UI;

public class ResultScoreDisplay : MonoBehaviour
{
    public Text scoreText; // スコアを表示するためのUIテキスト

    void Start()
    {
        // スコアを取得してテキストに反映
        int score = PlayerPrefs.GetInt("LastScore", 0); // スコアをロード（前のシーンから受け継いだものと仮定）
        string formattedScore = score.ToString("D4"); // 4桁のフォーマットに変換してテキストに表示
        scoreText.text = "Score: " + formattedScore + "pt";
    }
}
