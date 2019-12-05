using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StringScript : MonoBehaviour
{
    LineRenderer line;
    // Start is called before the first frame update
    void Start()
    {
        line = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        line.SetPosition(0, transform.parent.position);
        line.SetPosition(1, new Vector2(transform.parent.position.x + Mathf.Clamp(transform.parent.gameObject.GetComponent<Rigidbody2D>().velocity.x * 1.5f, -5, 5), line.GetPosition(1).y));
    }
}
