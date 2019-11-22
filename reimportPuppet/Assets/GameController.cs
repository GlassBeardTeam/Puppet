using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{

    int gears;

    // Start is called before the first frame update
    void Start()
    {
        gears = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void addGear()
    {
        gears++;
        Debug.Log("+1 punto");
        //TODO update HUD
        GameObject.Find("door").GetComponent<DoorScript>().showGear();
    }
}
