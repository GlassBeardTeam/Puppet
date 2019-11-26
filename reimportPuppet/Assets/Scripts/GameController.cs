﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{

    public Text coilText;
    public Text timerText;

    GameObject door;

    int gears;
    int coil;

    int minutes = 0;
    int seconds = 0;
    float tenths = 0;

    // Start is called before the first frame update
    void Start()
    {
        gears = 0;
        coil = 0;
        door = GameObject.FindGameObjectWithTag("door");
    }

    // Update is called once per frame
    void Update()
    {
        if (tenths > 99)
        {
            tenths = 0;
            seconds++;
            if(seconds > 59)
            {
                seconds = 0;
                minutes++;
            }
        }

        tenths += Time.deltaTime * 100;

        timerText.text = "" + minutes + " : " + seconds + " : " + (int)tenths;
    }

    public void addGear()
    {
        gears++;
        door.GetComponent<DoorScript>().showGear();
    }

    public void addCoil()
    {
        coil += 5;
        coilText.text = coil.ToString();
    }
}