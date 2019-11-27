using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float speed = 0.1f;
    public Vector3 offset = new Vector3(0, 0, -10);

    private void Start()
    {
        Debug.Log(transform.position);
    }
    private void LateUpdate()
    {
        Vector3 desiredPosition = target.position + offset;
        Vector3 nextPosition = Vector3.Lerp(transform.position, desiredPosition, speed);
        transform.position = nextPosition;
    }

}
