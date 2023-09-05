using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    //追いかけたいキャラ取得用の変数
    private GameObject chara;

    //距離の差用変数
    private float dif;

    // Start is called before the first frame update
    void Start()
    {
        //キャラのゲームオブジェクトを取得
        this.chara = GameObject.Find("MaleCharacterPBR");

        //キャラとカメラの位置（z座標）の差を求める
        this.dif = chara.transform.position.z - this.transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        //キャラの位置に合わせてカメラの位置を移動する
        this.transform.position = new Vector3(0, this.transform.position.y, this.chara.transform.position.z - dif);
    }
}
