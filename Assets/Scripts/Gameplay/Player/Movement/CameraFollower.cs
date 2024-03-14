using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    public Transform target;
    public float smoothSpeed = 0.125f;
    
    void Start()
    {
        transform.position = new Vector3(target.position.x, target.position.y, transform.position.z);
    }

    void Update()
    {
        Vector3 desiredPosition = new Vector3(target.position.x, target.position.y, transform.position.z);
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
        transform.position = smoothedPosition;
    }
}
