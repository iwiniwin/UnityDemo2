using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PingPongMotion : MonoBehaviour
{
    public float distance = 100f;
    public Vector3 moveAxis = Vector3.zero;

    private Vector3 origPos = Vector3.zero;
    // Start is called before the first frame update
    void Start()
    {
        origPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // Debug.Log(moveAxis * (Mathf.PingPong(Time.time, distance) * 0.01f* -1f + 0.5f));
        // Debug.Log(moveAxis * Mathf.PingPong(Time.time, distance));

        // -2.5 1.3

        transform.position = origPos + moveAxis * Mathf.PingPong(Time.time, distance);
        // transform.position = transform.position + Vector3.zero;
    }
}
