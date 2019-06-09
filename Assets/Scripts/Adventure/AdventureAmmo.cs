using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdventureAmmo : MonoBehaviour
{
    public float damage = 10f;

    public float lifeTime = 1f;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("Die", lifeTime);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player")){
            PlayerControl.health -= damage;
        }
    }

    public void Die(){
        Destroy(gameObject);
    }
}
