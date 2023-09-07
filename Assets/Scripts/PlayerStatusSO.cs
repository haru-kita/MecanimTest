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


    //����������Ă����Α��X�N���v�g����ϐ��ǂݍ��߂�H
    public int HP { get { return hp; } }
    public int ATTACK { get { return attack; } }
}
