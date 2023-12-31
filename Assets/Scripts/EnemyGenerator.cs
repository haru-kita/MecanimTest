using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    public GameObject[] enemyPrefabs; // 使用する敵Prefabのリスト
    public int maxEnemies; // 最大の敵の数
    private float interval; // 生成時間間隔
    private float time = 0f; // 経過時間

    // 生成済みのPrefabの位置を保存するリスト
    private List<Vector3> generatedPositions = new List<Vector3>();

    // レイヤーマスクを設定
    public LayerMask obstacleLayer;

    // 生成範囲の設定
    public float spawnRangeX;
    public float spawnRangeZ;

    void Start()
    {
        // 時間間隔（秒）を決定する
        interval = 1f;
    }

    void Update()
    {
        // 経過時間が生成時間になったとき
        if (time >= interval && generatedPositions.Count < maxEnemies)
        {
            // 指定された数だけランダムな敵Prefabを生成
            for (int i = 0; i < maxEnemies - generatedPositions.Count; i++)
            {
                int randomIndex = Random.Range(0, enemyPrefabs.Length);
                Vector3 randomPosition = GetRandomPosition();

                // 生成済みの位置と障害物との重なりを確認
                while (IsPositionOccupied(randomPosition))
                {
                    randomPosition = GetRandomPosition();
                }

                Quaternion randomRotation = Quaternion.Euler(0, Random.Range(-90f, 90f), 0); // -90から90度のランダムなY軸回転
                Instantiate(enemyPrefabs[randomIndex], randomPosition, randomRotation);

                // 生成位置を記録
                generatedPositions.Add(randomPosition);
            }

            // 経過時間を初期化
            time = 0f;
        }

        // 時間計測
        time += Time.deltaTime;
    }

    Vector3 GetRandomPosition()
    {
        Vector3 randomPosition;

        // オブジェクトを生成する位置をランダムに決定
        do
        {
            randomPosition = new Vector3(Random.Range(-spawnRangeX / 2, spawnRangeX / 2), 0f, Random.Range(-spawnRangeZ / 2, spawnRangeZ / 2));
        } while (IsPositionOccupied(randomPosition)); // 他のPrefabとの重なりを確認

        return randomPosition;
    }

    bool IsPositionOccupied(Vector3 position)
    {
        // 生成済みの位置との重なりを確認
        foreach (Vector3 generatedPos in generatedPositions)
        {
            if (Vector3.Distance(position, generatedPos) < 2f) // 2fの距離内に他のPrefabがある場合は重なりとみなす
            {
                return true;
            }
        }

        // レイキャストを使用して指定位置に障害物があるかどうかを確認
        float castDistance = 1f; // レイキャストの距離を設定
        RaycastHit hit;

        if (Physics.Raycast(position + Vector3.up, Vector3.down, out hit, castDistance, obstacleLayer))
        {
            // 指定位置に障害物がある場合、重なっているとみなす
            return true;
        }

        return false;
    }
}
