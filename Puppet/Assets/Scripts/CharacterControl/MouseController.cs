using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseController : MonoBehaviour
{
    public float force;
    public Vector2 forceDir;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = this.transform.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Debug.Log("Fuerza añadida");

            rb.AddForce(forceDir * force, ForceMode2D.Impulse);
        }
    }
}
