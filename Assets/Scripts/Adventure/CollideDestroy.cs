using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollideDestroy : MonoBehaviour
{
    public string tagName = string.Empty;

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag(tagName)){
            Destroy(gameObject);
        }
    }
}
