using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LegsPosManager : MonoBehaviour
{
    public Vector2 borderOffset;

    // Start is called before the first frame update
    void Start()
    {
        Transform left, right;
        left = transform.GetChild(0);
        right = transform.GetChild(1);

        float height = Camera.main.orthographicSize;
        Vector2 size = new Vector2(height * Camera.main.aspect, height);
        borderOffset *= size;

        left.localPosition = Vector2.zero;
        right.localPosition = Vector2.zero;
        float yPos = -size.y + borderOffset.y;
        left.localPosition = new Vector2((-size.x* 0.5f) + borderOffset.x, yPos);
        right.localPosition = new Vector2(size.x * 0.5f - borderOffset.x, yPos);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
