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


    //����������Ȃ��ƃG���[�ɂȂ�
    public int HP { get => hp; }
}
