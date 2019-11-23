using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{

    public Text gearsText;
    public Text coilText;

    int gears;
    int coil;

    // Start is called before the first frame update
    void Start()
    {
        gears = 0;
        coil = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void addGear()
    {
        gears++;
        gearsText.text = gears.ToString();
        GameObject.Find("door").GetComponent<DoorScript>().showGear();
    }

    public void addCoil()
    {
        coil += 5;
        coilText.text = coil.ToString();
    }
}
