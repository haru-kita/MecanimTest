using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu]
public class PlayerStatusSO : ScriptableObject
{
    [SerializeField] int hp;
    [SerializeField] int mp;
    [SerializeField] int attack;
    [SerializeField] int defence;


    //これを書いておけば他スクリプトから変数読み込める？
    public int PlayerHP { get { return hp; } }
    public int PlayerATTACK { get { return attack; } }
}
