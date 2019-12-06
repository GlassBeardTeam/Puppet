using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpringPlatform : MonoBehaviour
{
    AudioSource SpringEffect;
    GameObject bouncer;

    public float multiplier;
    public bool customJump;
    public Vector2 customVelocity;

    Vector2 velocity;
    Animator anim;
    Rigidbody2D rb;

    bool onTop;
    float initHeight;
    float yoffset = 0.1f;
    float upwardForce;

    // Start is called before the first frame update
    void Start()
    {
        SpringEffect = GameObject.FindGameObjectWithTag("bounceEffect").GetComponent<AudioSource>();
        SpringEffect.volume = PlayerPrefs.GetFloat("Volumen", 1.0f);

        anim = gameObject.GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        initHeight = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        /*
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
        */

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //rb.AddForce(new Vector2(0, 1500));
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        //rb.AddForce(new Vector2(0, 2000));
        if (onTop)
        {
            if (!SpringEffect.isPlaying)
            {
                SpringEffect.Play();
            }
            anim.SetBool("isStepped", true);
            if(collision.gameObject.tag == "PuppetPart")
            {
                bouncer = Puppet.Instace_.bodyParts[(int)BodyParts.TORSO];
            } else
            {
                bouncer = collision.gameObject;
            }
            
        }       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        onTop = true;
    }
    
    private void OnTriggerExit2D(Collider2D collision)
    {
        onTop = false;
        anim.SetBool("isStepped", false);
    }

    private void Jump()
    {
        if (customJump)
        {
            velocity = customVelocity;
        } else
        {
            velocity = transform.up * multiplier;
        }

        Rigidbody2D bouncerBody = bouncer.GetComponent<Rigidbody2D>();
        bouncerBody.velocity = velocity;
    }
}
