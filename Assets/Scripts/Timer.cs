using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// 当游戏在生成之后运行时，会从编号为0的scene开始

public class Timer : MonoBehaviour
{
    // Start is called before the first frame update
    public float maxTime = 60f;

    [SerializeField]
    private float remaindTime = 0f;
    void Start()
    {
        remaindTime = maxTime;
    }

    // Update is called once per frame
    void Update()
    {
        remaindTime -= Time.deltaTime;

        if (remaindTime <= 0){
            Coin.CoinCount = 0;
            Application.LoadLevel(Application.loadedLevel);
        }
    }

    public void PlayAudio(){
        GetComponent<AudioSource>().Play();
    }
}
