using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{

    //Audios

    AudioSource Colect1;
    AudioSource Colect2;

    public Text coilText;
    public Text timerText;
    public TelonScript telon;
    public int Level;

    GameObject door;

    int gears;
    int coil;

    int minutes = 0;
    int seconds = 0;
    float tenths = 0;

    bool countTime = false;

    // Start is called before the first frame update
    void Start()
    {
        Colect1 = GameObject.FindGameObjectWithTag("Col1Effect").GetComponent<AudioSource>();
        Colect2 = GameObject.FindGameObjectWithTag("Col2Effect").GetComponent<AudioSource>();

        Colect1.volume = PlayerPrefs.GetFloat("Volumen", 1.0f);
        Colect2.volume = PlayerPrefs.GetFloat("Volumen", 1.0f);

        PlayerPrefs.SetInt("level_play", Level);
        PlayerPrefs.SetInt("coil_level", 0);
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

        if(countTime)
            tenths += Time.deltaTime * 100;

        timerText.text = "" + minutes + " : " + seconds + " : " + (int)tenths;
        PlayerPrefs.SetInt("tiempo_act", minutes*6000+seconds*100+ (int)tenths);
    }

    public void addGear()
    {
        gears++;
        door.GetComponent<DoorScript>().showGear();
        if (gears >= 3)
        {
            door.GetComponent<DoorScript>().locked = false;
        }
        if (!Colect1.isPlaying)
        {
            Colect1.Play();
        }
    }

    public void addCoil()
    {
        coil += 5;
        coilText.text = coil.ToString();
        PlayerPrefs.SetInt("coil_level", coil);
        if (!Colect2.isPlaying)
        {
            Colect2.Play();
        }
    }

    public void startCounter()
    {
        countTime = true;
    }

    public void closeTelon()
    {
        telon.startAnimationDown();
    }

    public void endGame()
    {
        SceneManager.LoadScene(5);
        PlayerPrefs.SetInt("coil", PlayerPrefs.GetInt("coil", 0) + PlayerPrefs.GetInt("coil_level"));
    }

    public int getTenths()
    {
        return (int)tenths;
    }
    public int getMinutes()
    {
        return minutes;
    }
    public int getSeconds()
    {
        return seconds;
    }
}
