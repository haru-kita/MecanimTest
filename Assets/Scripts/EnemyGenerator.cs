using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    public GameObject[] enemyPrefabs; // �g�p����GPrefab�̃��X�g
    public int maxEnemies; // �ő�̓G�̐�
    private float interval; // �������ԊԊu
    private float time = 0f; // �o�ߎ���

    // �����ς݂�Prefab�̈ʒu��ۑ����郊�X�g
    private List<Vector3> generatedPositions = new List<Vector3>();

    // ���C���[�}�X�N��ݒ�
    public LayerMask obstacleLayer;

    // �����͈͂̐ݒ�
    public float spawnRangeX;
    public float spawnRangeZ;

    void Start()
    {
        // ���ԊԊu�i�b�j�����肷��
        interval = 1f;
    }

    void Update()
    {
        // �o�ߎ��Ԃ��������ԂɂȂ����Ƃ�
        if (time >= interval && generatedPositions.Count < maxEnemies)
        {
            // �w�肳�ꂽ�����������_���ȓGPrefab�𐶐�
            for (int i = 0; i < maxEnemies - generatedPositions.Count; i++)
            {
                int randomIndex = Random.Range(0, enemyPrefabs.Length);
                Vector3 randomPosition = GetRandomPosition();

                // �����ς݂̈ʒu�Ə�Q���Ƃ̏d�Ȃ���m�F
                while (IsPositionOccupied(randomPosition))
                {
                    randomPosition = GetRandomPosition();
                }

                Quaternion randomRotation = Quaternion.Euler(0, Random.Range(-90f, 90f), 0); // -90����90�x�̃����_����Y����]
                Instantiate(enemyPrefabs[randomIndex], randomPosition, randomRotation);

                // �����ʒu���L�^
                generatedPositions.Add(randomPosition);
            }

            // �o�ߎ��Ԃ�������
            time = 0f;
        }

        // ���Ԍv��
        time += Time.deltaTime;
    }

    Vector3 GetRandomPosition()
    {
        Vector3 randomPosition;

        // �I�u�W�F�N�g�𐶐�����ʒu�������_���Ɍ���
        do
        {
            randomPosition = new Vector3(Random.Range(-spawnRangeX / 2, spawnRangeX / 2), 0f, Random.Range(-spawnRangeZ / 2, spawnRangeZ / 2));
        } while (IsPositionOccupied(randomPosition)); // ����Prefab�Ƃ̏d�Ȃ���m�F

        return randomPosition;
    }

    bool IsPositionOccupied(Vector3 position)
    {
        // �����ς݂̈ʒu�Ƃ̏d�Ȃ���m�F
        foreach (Vector3 generatedPos in generatedPositions)
        {
            if (Vector3.Distance(position, generatedPos) < 2f) // 2f�̋������ɑ���Prefab������ꍇ�͏d�Ȃ�Ƃ݂Ȃ�
            {
                return true;
            }
        }

        // ���C�L���X�g���g�p���Ďw��ʒu�ɏ�Q�������邩�ǂ������m�F
        float castDistance = 1f; // ���C�L���X�g�̋�����ݒ�
        RaycastHit hit;

        if (Physics.Raycast(position + Vector3.up, Vector3.down, out hit, castDistance, obstacleLayer))
        {
            // �w��ʒu�ɏ�Q��������ꍇ�A�d�Ȃ��Ă���Ƃ݂Ȃ�
            return true;
        }

        return false;
    }
}
