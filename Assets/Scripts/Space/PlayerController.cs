using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public string hAxis = "Horizontal";
    public string vAxis = "Vertical";
    public string fireAxis = "Fire1";
    public float maxSpeed = 5f;
    public bool mouseLook = true;

    public Rigidbody rigidbody;
    public Transform transform;

    public Transform[] turrets;
    public bool canFire = true;
    public float reloadDelay = 2.0f;

    private void Awake() {
        rigidbody = GetComponent<Rigidbody>();
        transform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        // Input.GetAxis 从键盘或者手柄上读取轴向的输入数据
        // 水平和垂直两个方向的输入值区间为-1到1 如果没有键按下就是0 
        // 给刚体施加一个力
        Vector3 moveDirection = new Vector3(Input.GetAxis(hAxis), 0, Input.GetAxis(vAxis));
        rigidbody.AddForce(moveDirection.normalized * maxSpeed);

        // 限制速度
        rigidbody.velocity = new Vector3(Mathf.Clamp(rigidbody.velocity.x, -maxSpeed, maxSpeed), 
        Mathf.Clamp(rigidbody.velocity.y, -maxSpeed, maxSpeed), 
        Mathf.Clamp(rigidbody.velocity.z, -maxSpeed, maxSpeed));

        // 是否跟随鼠标
        if (mouseLook){
            // ScreenToWorldPoint 用于将光标在屏幕上的坐标转换为在游戏世界的坐标
            Vector3 mousePosWorld = Camera.main.ScreenToWorldPoint(new Vector3(
                Input.mousePosition.x, Input.mousePosition.y, 0.0f
            ));
            mousePosWorld = new Vector3(mousePosWorld.x, 0.0f, mousePosWorld.z);

            // 跟随光标的方向
            Vector3 lookDirection = mousePosWorld - transform.position;

            transform.localRotation = Quaternion.LookRotation(lookDirection.normalized, Vector3.up);
        }

        if (Input.GetButtonDown(fireAxis) && canFire){
            foreach (Transform item in turrets)
            {
                AmmoManager.Spawn(item.position, item.rotation);
                canFire = false;
                Invoke("EnableFire", reloadDelay);
            }
        }
    }

    public void EnableFire(){
        canFire = true;
    }

    public void Die(){
        Destroy(gameObject);
    }
}
