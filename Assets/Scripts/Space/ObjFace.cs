using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjFace : MonoBehaviour
{
    public GameObject obj;
    private Transform transform;
    public bool followObject = true;
    // Start is called before the first frame update
    void Start()
    {
        if (!followObject)
            return;
        transform = GetComponent<Transform>();
        obj = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if(obj){
            Vector3 direction = obj.transform.position - transform.position;
            if (direction != Vector3.zero){
                transform.localRotation = Quaternion.LookRotation(direction.normalized, Vector3.up);
            }
        }
    }
}
