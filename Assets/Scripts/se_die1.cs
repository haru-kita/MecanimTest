using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class se_die1 : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioClip destructionSound;

    private void Start()
    {
        // AudioSourceコンポーネントを取得
        audioSource = GetComponent<AudioSource>();
    }

    private void OnDestroy()
    {
        // 敵が破壊されたときに効果音を再生
        audioSource.PlayOneShot(destructionSound);
    }
}
