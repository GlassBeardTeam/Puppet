using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpringPlatform : MonoBehaviour
{
    Rigidbody2D rb;
    float initHeight;
    float yoffset = 0.2f;
    float upwardForce = 1000;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        initHeight = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        rb.AddForce(new Vector2(0, upwardForce));
        if(transform.position.y > initHeight + yoffset)
        {
            transform.position = new Vector2(transform.position.x, initHeight + yoffset);
            upwardForce = 1000;
        }
        else if(transform.position.y < initHeight - yoffset)
        {
            upwardForce = 3000;
        }
    }
}
