using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    Stack<GameObject> gears = new Stack<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(false);
            gears.Push(child.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void showGear()
    {
        gears.Pop().SetActive(true);

        if(gears.Count == 0)
        {
            //abrir puerta
        }
    }
}
