using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyManager : MonoBehaviour
{
    [SerializeField] EnemyStatusSO enemyStatusSO;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(enemyStatusSO.enemyStatusList[0].HP);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
