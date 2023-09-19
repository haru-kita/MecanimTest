using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordController : MonoBehaviour
{
    public GameObject hitEffectPrefab; // �q�b�g�G�t�F�N�g�̃v���n�u

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("Enemy"))
        {
            // �q�b�g�G�t�F�N�g�𐶐����āA���ƓG�̏Փ˂����ꏊ�ɔz�u
            Vector3 hitPosition = col.ClosestPointOnBounds(transform.position);
            GameObject hitEffect = Instantiate(hitEffectPrefab, hitPosition, Quaternion.identity);

            // �q�b�g�G�t�F�N�g���폜�i�p�[�e�B�N���̃��C�t�^�C�����I�������玩���I�ɍ폜�����j
            Destroy(hitEffect, hitEffect.GetComponent<ParticleSystem>().main.duration);
        }
    }
}
