using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu_selector : MonoBehaviour
{

    public static int val_language = 0;
    string[] Level_array = new string[] { "Nivel", "Level" };
    string[] Sala_array = new string[] { "Sala", "Room" };
    public Text text_Lvl1;
    public Text text_Lvl2;
    public Text text_Lvl3;
    public Text text_sala;

    void Start()
    {
        //change_language();
        Debug.Log("sss");
    }

    public void PlayGame(int scene)
    {
        SceneManager.LoadScene(scene);
    }

    public void Volver()
    {
        SceneManager.LoadScene(0);
    }

    public void change_language()
    {
        //text_Lvl1.text = Level_array[val_language];
        // text_Lvl2.text = Level_array[val_language];
        //text_Lvl3.text = Level_array[val_language];
        // text_sala.text = Sala_array[val_language];
    }
}
