using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    bool collected = false;

    float animationTime = 0.5f;
    float currentAnimationTime = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (collected)
        {
            currentAnimationTime += Time.deltaTime;
            transform.localScale += new Vector3(currentAnimationTime, currentAnimationTime, 0) * 2;
            Color tmp = GetComponent<SpriteRenderer>().color;
            tmp.a -= currentAnimationTime*2;
            GetComponent<SpriteRenderer>().color = tmp;
            if (currentAnimationTime >= animationTime)
                Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collected)
        {
            collected = true;
            GameObject.Find("GameController").GetComponent<GameController>().addGear();
        }
           
    }
}
