using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowScript : MonoBehaviour
{
    public Transform targetObject;
    public Vector3 cameraOffset;

    public float smoothFactor = 0.5f;

    public bool lookAtTarget = false;

    // Start is called before the first frame update
    void Start()
    {
        cameraOffset = transform.position - targetObject.transform.position;
    }

    // LateUpdate is called once per frame after Update is called
    void LateUpdate()
    {
        Vector3 newPos = targetObject.transform.position + cameraOffset;
        //        transform.position = newPos;
        transform.position = Vector3.Slerp(transform.position, newPos, smoothFactor);
        
        if (lookAtTarget)
        {
            transform.LookAt(targetObject);
        }
    }
}
