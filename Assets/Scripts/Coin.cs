using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public static int CoinCount = 0;
    // private AudioSource destoryAudio;

    void Start()
    {
        Coin.CoinCount ++;
        // destoryAudio = this.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDestroy() {
        Coin.CoinCount --;

        if(Coin.CoinCount <= 0){
            // 如果场景中包含了多个符合条件的对象，那么只返回第一个对象
            // 尽可能避免使用Find，执行效率很低
            GameObject timer = GameObject.Find("LevelTimer");
            Destroy(timer);

            GameObject[] fireworks = GameObject.FindGameObjectsWithTag("Firework");
            foreach(GameObject firework in fireworks){
                // GetComponent可以获得一个目标组件的引用
                firework.GetComponent<ParticleSystem>().Play();
            }
        }
    }

    private void OnTriggerEnter(Collider other) {
        // 确定是玩家触发
        if (other.CompareTag("Player"))
            GameObject.Find("LevelTimer").GetComponent<Timer>().PlayAudio();
            Destroy(gameObject);
    }

    // FixedUpdate主要用来实现物理编码 每秒执行固定的次数
    // LateUpdate被每个活动的对象在每一帧调用一次 总是发生在Update之后

    // Time.deltaTime 被unity不断更新的静态变量，用来描述自上一帧结束后到现在的时间量 以秒为单位
}
