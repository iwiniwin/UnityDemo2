using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillZone : MonoBehaviour
{
    public float damage = 100f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // 当一个具有刚体组件的对象进入到触发区域之后，Unity就会自动调用OnTriggerStay2D函数，频率为每帧一次
    private void OnTriggerStay2D(Collider2D other) {
        if (other.CompareTag("Player")){
            // other.gameObject.GetComponent<PlayerControl>().health -= damage;
            if (PlayerControl.playerInstance != null)
                PlayerControl.health -= damage * Time.deltaTime;
        }
    }
}
