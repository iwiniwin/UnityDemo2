using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundsLock : MonoBehaviour
{
    public Vector2 horRange = Vector2.zero;
    public Vector2 verRange = Vector2.zero;
    private Transform transform;
    // Start is called before the first frame update
    private void Awake() {
        transform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = new Vector3(
            Mathf.Clamp(transform.position.x, horRange.x, horRange.y),
            transform.position.y, 
            Mathf.Clamp(transform.position.z, verRange.x, verRange.y)
        );
    }
}
