using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoSpawner : MonoBehaviour
{
    public GameObject bulletPrefab;

    public Vector2 timeDealyRange;


    public float ammoLifeTime = 2f;
    public float ammoSpeed = 4f;
    public float ammoDamage = 10f;
    // Start is called before the first frame update
    void Start()
    {
        FireAmmo();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FireAmmo(){
        GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
        AdventureAmmo ammoComp = bullet.GetComponent<AdventureAmmo>();
        ammoComp.lifeTime = ammoLifeTime;
        ammoComp.damage = ammoDamage;
        bullet.GetComponent<AdventureMover>().speed = ammoSpeed;


        Invoke("FireAmmo", Random.Range(timeDealyRange.x, timeDealyRange.y));
    }
}
