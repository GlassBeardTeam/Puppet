using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacher : MonoBehaviour
{
    HingeJoint2D hj;
    GameObject container;
    // Start is called before the first frame update
    void Start()
    {
        hj = GetComponent<HingeJoint2D>();
        container = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if( collision.gameObject.layer == 8 && hj != null)
        {
            BroadcastMessage("unattach");
            unattach();
            container.GetComponent<RespawnController>().die();
        }
        
        if(collision.gameObject.layer == 9)
        {

        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "checkpoint")
        {
            container.GetComponent<RespawnController>().setLastCheckpoint(collision.gameObject);
        }
    }

    void unattach()
    {
        Destroy(hj);
        gameObject.GetComponent<Rigidbody2D>().AddForce(Random.insideUnitCircle * 100);
    }
}
