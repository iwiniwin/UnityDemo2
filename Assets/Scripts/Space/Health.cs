using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    // 序列化字段
    [SerializeField]
    private float _healthPoints = 100f;

    public bool destroyOnDeath = true;
    public GameObject deathParticlePrefab = null;
    private Transform transform;

    private void Awake() {
        transform = GetComponent<Transform>();
    }

    public float healthPoints{
        get {
            return _healthPoints;
        }
        set {
            _healthPoints = value;
            if (_healthPoints <= 0){
                // SendMessage允许通过名字来调用依附在对象的组件所提供的公共函数
                // SendMessage内部使用的是反射，耗费资源且执行缓慢，一般很少使用，尤其不能用于频繁发生的事件
                SendMessage("Die", SendMessageOptions.DontRequireReceiver);

                if (deathParticlePrefab != null){
                    Instantiate(deathParticlePrefab, transform.position, transform.rotation);
                }
                if (destroyOnDeath)
                    Destroy(gameObject);
            }
        }
    }

    private void Update() {
        // if (Input.GetKeyDown(KeyCode.Space)){
        //     healthPoints = 0;
        // }
    }
}
