using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackController : MonoBehaviour
{
    private Animator anim;
    public AudioClip sound1;
    private AudioSource audioSource;

    private bool isRotating; // 新しい変数を追加

    void Start()
    {
        anim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        isRotating = false; // 初期状態では回転攻撃はオフ
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            anim.SetTrigger("Attack");
            audioSource.PlayOneShot(sound1);
        }

        // マウスの右クリックが押されている間、回転攻撃を実行
        if (Input.GetMouseButton(1))
        {
            isRotating = true;
        }
        else
        {
            isRotating = false;
        }

        // 回転攻撃の実行状態に応じてトリガーをセット
        if (isRotating)
        {
            anim.SetTrigger("RotAttack");
        }
    }
}
