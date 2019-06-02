using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    public float dammage = 100f;
    public float lifeTime = 2.0f;

    private void OnEnable() {
        // 取消所有的invoke调用
        CancelInvoke();
        Invoke("Die", lifeTime);
    }

    private void OnTriggerEnter(Collider other) {
        Health h = other.GetComponent<Health>();
        if (h){
            h.healthPoints -= dammage;
        }
    }

    private void Die(){
        gameObject.SetActive(false);
    }
}
