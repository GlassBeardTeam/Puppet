using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{

    public Text coilText;
    public Text timerText;

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
    }

    // Update is called once per frame
    void Update()
    {
        if (tenths > 9)
        {
            seconds++;
            if(seconds > 59)
            {
                minutes++;
            }
        }

        tenths += Time.deltaTime * 10;

        timerText.text = "" + minutes + " : " + seconds + " : " + (int)tenths;
    }

    public void addGear()
    {
        gears++;
        GameObject.Find("door").GetComponent<DoorScript>().showGear();
    }

    public void addCoil()
    {
        coil += 5;
        coilText.text = coil.ToString();
    }
}
