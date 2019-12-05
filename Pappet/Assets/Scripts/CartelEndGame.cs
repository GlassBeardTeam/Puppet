using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CartelEndGame : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        updateText();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void updateText()
    {
        transform.GetChild(0).GetChild(0).GetComponent<Text>().text = PlayerPrefs.GetInt("coil", 0).ToString();
    }
}
