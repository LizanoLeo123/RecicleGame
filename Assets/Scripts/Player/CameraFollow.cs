using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // Target object
    [SerializeField] Transform targetObject;

    // Default distance between the target and the player
    [SerializeField] Vector3 cameraOffset;

    // Smooth factor will use in Camera Rotation
    [SerializeField] float SmoothFactor = 0.5f;

    // Start is called before the first frame update
    [SerializeField] bool lookAtTarget = false;

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
