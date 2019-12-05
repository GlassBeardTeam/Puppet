using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleCoil : MonoBehaviour
{
    bool collected = false;

    float currentAnimationTime = 0;
    float animationTime = 0.5f;

    [Range(0.1f, 10.0f)]
    public float speed = 1.0f;
    [Range(0.1f, 10.0f)]
    public float Amplitud = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Movement());
    }

    IEnumerator Movement()
    {
        float x = 0.0f;
        float initYPos = this.transform.position.y;
        while (true)
        {
            x += Time.deltaTime;
            float sin = Amplitud *Mathf.Sin(x * speed);
            Vector3 currentPos = this.transform.position;
            currentPos.y = initYPos + sin;
            this.transform.position = currentPos;
            yield return null;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (collected)
        {
            currentAnimationTime += Time.deltaTime;
            transform.localScale += new Vector3(currentAnimationTime, currentAnimationTime, 0) * 2;
            Color tmp = GetComponent<SpriteRenderer>().color;
            tmp.a -= currentAnimationTime * 2;
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
            GameObject.Find("GameController").GetComponent<GameController>().addCoil();
        }

    }
}
