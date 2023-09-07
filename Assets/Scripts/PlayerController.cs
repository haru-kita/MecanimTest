using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    private Animator anim;
    private float speed = 5.0f; //移動速度
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

        // 前移動
        if (Input.GetKey(KeyCode.W))
        {
            rb.velocity = transform.forward * speed;
            this.anim.SetBool("Run" , true);
        }

        // 後移動
        if (Input.GetKey(KeyCode.S))
        {
            rb.velocity = - transform.forward * speed;
            this.anim.SetBool("Run" , true);
        }

        // 右移動
        if (Input.GetKey(KeyCode.D))
        {
            rb.velocity = transform.right * speed;
            this.anim.SetBool("Run" , true);
        }

        // 左移動
        if (Input.GetKey(KeyCode.A))
        {
            rb.velocity = -transform.right * speed;
            this.anim.SetBool("Run" , true);
        }

        //キーを離すとIdleに戻る
        if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.A)  )
        {
            anim.SetBool("Run" , false);
        }

        //キーマウスがクリックされた場合
        if (Input.GetMouseButtonDown (0))
        {
            //Animatorコンポーネントを取得し"Attock"をtrueにする
            this.anim.SetTrigger("Attack");
        }

    }

    //他のオブジェクトと接触した場合の処理
    void OnCollisionEnter(Collision col)
    {
        //HPを減らす
        currentHP = currentHP - 10;
    }

}

