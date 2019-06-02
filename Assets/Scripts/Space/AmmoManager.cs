using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoManager : MonoBehaviour
{
    public GameObject ammoPrefab;
    public int poolSize = 100;
    private Queue<GameObject> ammoPool;

    public static AmmoManager ammoManagerSingleton;
    
    private void Awake() {
        // 单例
        if (ammoManagerSingleton != null) {
            Destroy(GetComponent<AmmoManager>());
            return;
        }

        ammoManagerSingleton = this;

        ammoPool = new Queue<GameObject>();

        for (int i = 0; i < poolSize; i++)
        {
            GameObject ammo = Instantiate(ammoPrefab, Vector3.zero, Quaternion.identity);
            ammo.transform.parent = transform;
            ammoPool.Enqueue(ammo);
            ammo.SetActive(false);
        }
            

    }

    public static Transform Spawn(Vector3 position, Quaternion rotation){
        GameObject ammo = ammoManagerSingleton.ammoPool.Dequeue();
        ammo.transform.position = position;
        ammo.transform.localRotation = rotation;
        ammo.SetActive(true);

        ammoManagerSingleton.ammoPool.Enqueue(ammo);

        ammoManagerSingleton.GetComponent<AudioSource>().Play();

        return ammo.transform;
    }
}
