using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseMoverFoo : MonoBehaviour
{
    public float force;
    public Rigidbody2D target;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Mouse0))
        {
            Vector2 moveDir = (target.position - (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition));
            target.AddForce(-moveDir.normalized * force);
        }
    }
}
