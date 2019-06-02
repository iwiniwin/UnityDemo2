using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProxyDamage : MonoBehaviour
{
    public float damage = 10.0f;
    public int score = 50;
    
    // private void OnTriggerStay(Collider other) {
    //     Health health = other.GetComponent<Health>();
    //     if (health){
    //         health.healthPoints -= damage * Time.deltaTime;
    //     }
    // }
    private void OnTriggerEnter(Collider other) {
        Health health = other.GetComponent<Health>();
        if (health){
            health.healthPoints -= damage;
            GameController.health = health.healthPoints;
            GetComponent<Health>().healthPoints = 0;
        }
    }

    private void OnDestroy() {
        GameController.score += score;
        GameController.Play();
    }
}
