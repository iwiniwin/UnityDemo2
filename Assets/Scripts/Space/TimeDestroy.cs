using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeDestroy : MonoBehaviour
{
    public float destroyTime = 2.0f;
    // Start is called before the first frame update
    void Start()
    {
        // Invoke会在特定的时间间隔结束以后执行一次特定名称的函数，时间以秒为单位
        // 同样基于反射 为了保证系统的性能 应该谨慎使用
        Invoke("Die", destroyTime);
    }

    public void Die(){
        Destroy(gameObject);
    }
}
