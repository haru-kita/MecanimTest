using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu]
public class EnemyStatusSO : ScriptableObject
{
    public List<EnemyStatus> enemyStatusList = new List<EnemyStatus>();

    [System.Serializable]
    public class EnemyStatus
    {
        [SerializeField] string EnemyName;
        [SerializeField] int hp;
        [SerializeField] int mp;
        [SerializeField] int attack;
        [SerializeField] int defence;

        //‚±‚ê‚ð‘‚©‚È‚¢‚ÆƒGƒ‰[‚É‚È‚é
        public int EnemyHP { get => hp;}
        public int EnemyDEFENCE { get => defence; }
    }


}
