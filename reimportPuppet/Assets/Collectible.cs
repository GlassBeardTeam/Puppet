﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    bool collected = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collected)
        {
            collected = true;
            Destroy(gameObject);
            GameObject.Find("GameController").GetComponent<GameController>().addGear();
        }
           
    }
}