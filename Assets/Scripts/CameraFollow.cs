using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // Target object
    public Transform targetObject;

    // Default distance between the target and the player
    public Vector3 cameraOffset;

    // Smooth factor will use in Camera Rotation
    public float SmoothFactor = 0.5f;

    // Start is called before the first frame update
    public bool lookAtTarget = false;

    void Start()
    {
        cameraOffset = transform.position - targetObject.transform.position;
    }

    void LateUpdate()
    {
        Vector3 newPosition = targetObject.transform.position + cameraOffset;
        transform.position = Vector3.Slerp(transform.position, newPosition, SmoothFactor);
    
        // Camera Rotation
        if(lookAtTarget){
            transform.LookAt(targetObject);
        }
    }
}
