using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpController : MonoBehaviour
{
    public Collider2D[] allBodyParts;
    public BoxCollider2D[] colliderChecker;
    // Start is called before the first frame update
    void Start()
    {
        IgnoreCollision();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void CollisionManager(Collision2D collision)
    {
        ContactFilter2D cf = new ContactFilter2D();
        foreach(BoxCollider2D checker in colliderChecker)
        {
            Collider2D[] results = new Collider2D[10];
            checker.OverlapCollider(cf , results);
            foreach(Collider2D res in results)
            {
                Debug.Log("Result: " + res.name);
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        CollisionManager(collision);
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        CollisionManager(collision);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }
    void IgnoreCollision()
    {
        foreach(Collider2D part in allBodyParts)
        {
            foreach(Collider2D checker in colliderChecker)
            {
                Physics2D.IgnoreCollision(part, checker);
                Physics2D.IgnoreCollision(checker, part);
            }
        }
    }
}
