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
    public int PlayerHP { get { return hp; } }
    public int PlayerATTACK { get { return attack; } }
}
