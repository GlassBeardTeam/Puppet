using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float speed = 1.0f;

    Rigidbody2D rg;

    private void Start()
    {
        rg = GetComponent<Rigidbody2D>();
    }
    private void LateUpdate()
    {
        rg.velocity = (target.GetChild(0).GetChild(0).position - transform.position)*speed;
    }

}
