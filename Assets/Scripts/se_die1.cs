using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class se_die1 : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioClip destructionSound;

    private void Start()
    {
        // AudioSource�R���|�[�l���g���擾
        audioSource = GetComponent<AudioSource>();
    }

    private void OnDestroy()
    {
        // �G���j�󂳂ꂽ�Ƃ��Ɍ��ʉ����Đ�
        audioSource.PlayOneShot(destructionSound);
    }
}
