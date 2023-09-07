using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    private Animator anim;

    private int currentHP;

    [SerializeField] PlayerStatusSO playerStatusSO;
    [SerializeField] Text hpText;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        //HPコンポーネントを取得
        hpText.GetComponent<Text>().text = "HP:" + currentHP.ToString();
        //playerStatusSOコンポーネントのHPの値を代入
        currentHP = playerStatusSO.HP;

    }

    // Update is called once per frame
    void Update()
    {
        //HPを取得
        hpText.GetComponent<Text>().text = "HP:" + currentHP.ToString();

        //キーマウスがクリックされた場合
        if (Input.GetMouseButtonDown (0))
        {
            //Animatorコンポーネントを取得し"Attock"トリガーを実行する
            this.anim.SetTrigger("Attack");
        }

    }

}

