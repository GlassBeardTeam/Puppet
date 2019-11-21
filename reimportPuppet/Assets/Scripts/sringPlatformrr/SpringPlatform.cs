using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpringPlatform : MonoBehaviour
{
    Rigidbody2D rb;
    float initHeight;
    float yoffset = 0.0f;
    float upwardForce;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        initHeight = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        upwardForce = Mathf.Pow(((initHeight - transform.position.y)*2), 11);
        rb.AddForce(new Vector2(0, upwardForce));
        if(transform.position.y > initHeight + yoffset)
        {
            transform.position = new Vector2(transform.position.x, initHeight + yoffset);
        }
        
    }
}
