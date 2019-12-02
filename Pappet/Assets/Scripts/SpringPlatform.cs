using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpringPlatform : MonoBehaviour
{
    Rigidbody2D rb;
    float initHeight;
    float yoffset = 0.1f;
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
        upwardForce = Mathf.Clamp(Mathf.Pow(((initHeight - transform.position.y)*2), 10), 0, 10000);
        rb.AddForce(new Vector2(0, upwardForce));
        if(transform.position.y > initHeight)
        {
            transform.position = new Vector2(transform.position.x, initHeight);
            rb.velocity = new Vector2(0, 0);
        }
        else
        {
            upwardForce = Mathf.Clamp(Mathf.Pow(((initHeight - transform.position.y) * 2), 10), 0, 30000);
        }
        rb.AddForce(new Vector2(0, upwardForce));

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //rb.AddForce(new Vector2(0, 1500));
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        rb.AddForce(new Vector2(0, 2000));

    }
}
