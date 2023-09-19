using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAttackController : MonoBehaviour
{
    private Rigidbody rb;
    private Animator anim;
    private int currentHP;

    [SerializeField] PlayerStatusSO playerStatusSO;
    [SerializeField] Text hpText;

    public AudioClip sound1;
    AudioSource audioSource;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        //HPコンポーネントを取得
        hpText.GetComponent<Text>().text = "HP:" + currentHP.ToString();
        //playerStatusSOコンポーネントのHPの値を代入
        currentHP = playerStatusSO.PlayerHP;
        // サウンドのコンポーネントを取得
        audioSource = GetComponent<AudioSource>();
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

            // 武器音(sound1)を鳴らす
            audioSource.PlayOneShot(sound1);
        }

    }

}

