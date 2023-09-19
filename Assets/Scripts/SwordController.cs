using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordController : MonoBehaviour
{
    public GameObject hitEffectPrefab; // ヒットエフェクトのプレハブ

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("Enemy"))
        {
            // ヒットエフェクトを生成して、剣と敵の衝突した場所に配置
            Vector3 hitPosition = col.ClosestPointOnBounds(transform.position);
            GameObject hitEffect = Instantiate(hitEffectPrefab, hitPosition, Quaternion.identity);

            // ヒットエフェクトを削除（パーティクルのライフタイムが終了したら自動的に削除される）
            Destroy(hitEffect, hitEffect.GetComponent<ParticleSystem>().main.duration);
        }
    }
}
