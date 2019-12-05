﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controlador_auto_personaje : MonoBehaviour
{
    public Puppet Personaje;
    public float period;
    public float nextActionTime;
    public float ActionDuration;
    public float endActionTime;
    public float endActionNext;
    public float time;
    int nextmove;
    // Start is called before the first frame update
    void Start()
    {
        period = 0.9f;
        nextActionTime = 0.0f;
        ActionDuration = 0.4f;
        endActionTime = 0.4f;
        endActionNext = 0.0f;
        nextmove = 0;

    }

    // Update is called once per frame
    void Update()
    {
        time = Time.time;
        if (Time.time > nextActionTime)
        {
            nextActionTime += period;
            endActionTime = endActionNext;
            endActionNext = nextActionTime+ActionDuration;
            if (nextmove == 0)
            {
                nextmove = 1;
            }
            else
            {
                nextmove = 0;
            }
        }
        else
        {
            if (Time.time< endActionTime)
            {
                if (nextmove == 0)
                {
                    Personaje.FlexRight();
                }
                else
                {
                    Personaje.FlexLeft();
                }
            }
        }
    }
}