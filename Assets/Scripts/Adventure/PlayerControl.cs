using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.SceneManagement;

public class PlayerControl : MonoBehaviour
{
    public enum FACEDIRECTION {
        FACELEFT = -1,
        FACERIGHT = 1
    }

    public FACEDIRECTION facing = FACEDIRECTION.FACERIGHT;

    // tag被标记为地面的对象
    public LayerMask ground;

    // 是否触碰到地面
    public bool isGrounded = false;
    // 是否可以跳跃
    private bool canJump = true;
    // 是否可以控制角色
    private bool canControl = true;

    private string verAxis = "Vertical";
    private string horAxis = "Horizontal";
    private string jumpButton = "Jump";

    private Rigidbody2D rigidbody;
    // private CircleCollider2D collider;
    public CircleCollider2D collider;

    public float speed = 100f;
    public float jumpPower = 600f;
    public float jumpTimeOut = 1f;

    public static PlayerControl playerInstance = null;

    // 生命值
    [SerializeField]
    private static float _health = 100f;
    public static float health{
        get {
            return _health;
        }

        set {
            Debug.Log(value);
            _health = value;
            if (_health <= 0){
                Die();
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        collider = GetComponent<CircleCollider2D>();

        // 设置静态实例
        playerInstance = this;
    }

    // Update is called once per frame
    // void Update()
    // {
    //     // transform.position = 
    //     // Input.GetAxis(horAxis);
    //     rigidbody.AddForce(new Vector3(Input.GetAxis(horAxis) * speed * Time.deltaTime, 0, 0));

    //     Debug.Log(Input.GetAxis(horAxis) * speed * Time.deltaTime);
    // }

    private void FixedUpdate() {
        if (!canControl || health <= 0)
            return;

        // 更新isGrounded状态
        isGrounded = GetGrounded();

        if (CrossPlatformInputManager.GetButtonDown(jumpButton)){
            if (isGrounded && canJump){
                Jump();
            }
        }

        float hor = CrossPlatformInputManager.GetAxis(horAxis);
        rigidbody.AddForce(Vector2.right * hor * speed);
        // rigidbody.AddForce(Vector2.up * CrossPlatformInputManager.GetAxis(verAxis) * speed);

        // 对速度进行限制
        // 给速度赋在-speed和speed之间的值
        rigidbody.velocity = new Vector2(Mathf.Clamp(rigidbody.velocity.x, -speed, speed), 
            Mathf.Clamp(rigidbody.velocity.y, -Mathf.Infinity, jumpPower));

        if ((hor > 0 && facing != FACEDIRECTION.FACERIGHT) || (hor < 0 && facing != FACEDIRECTION.FACELEFT)) {
            FlipDriection();
        }

        if (transform.position.x < -5){
            SceneManager.LoadScene("Adventure2Scene");
        }else if (transform.position.x > 3.5){
            SceneManager.LoadScene("Adventure3Scene");
        }
            

        // Vector3 position = transform.position;
        // transform.position = new Vector3(Mathf.Clamp(position.x, -5.8f, Mathf.Infinity), 
        //     Mathf.Clamp(position.y, 0.1f, 200), 0);
    }


    public void Jump(){
        rigidbody.AddForce(Vector2.up * jumpPower);
    }

    public bool GetGrounded(){
        // 检测地面
        Vector2 circleCenter = new Vector2(transform.position.x, transform.position.y) + collider.offset;

        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(circleCenter, collider.radius, ground);

        if (hitColliders.Length > 0) return true;

        return false;
    }

    public void FlipDriection(){
        // transform.localRotation = Quaternion.
        facing = (FACEDIRECTION)((int)facing * -1f);
        
        Vector3 localScale = transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }

    public static void Die(){
        Destroy(playerInstance.gameObject);
    }

    private void OnDestroy() {
        Debug.Log("destroy ........");
        playerInstance = null;
    }

    public void Reset(){
        health = 100f;
    }
    
}
