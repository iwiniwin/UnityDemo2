using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject objToSpawn;
    public float interval = 2f;
    private Transform origin;
    public float maxRaidus = 5f; 
    // Start is called before the first frame update
    void Start()
    {
        origin = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

        // 在0秒内调用spawn方法 每interval秒重复一次
        InvokeRepeating("Spawn", 0f, interval);
    }

    void Spawn(){
        if (origin == null) return;
        Vector3 position = origin.position + Random.onUnitSphere * maxRaidus;
        position = new Vector3(position.x, 0.0f, position.z);
        GameObject enemy = Instantiate(objToSpawn, position, Quaternion.identity);
    }
}
