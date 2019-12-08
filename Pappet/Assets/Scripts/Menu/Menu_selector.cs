using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu_selector : MonoBehaviour
{

    public static int val_language;
    string[] Level_array = new string[] { "Nivel", "Level" };
    string[] Sala_array = new string[] { "Sala", "Room" };
    string[] Time_array = new string[] { "Tiempo", "Time" };
    /*int[] Minutes_array;
    int[] Sec_array;
    int[] Tenth_array;*/
    int[] times_array;

    [SerializeField] private Button ButonLev1; 
    [SerializeField] private Button ButonLev2;
    [SerializeField] private Button ButonLev3;

    [SerializeField] private Text text_Lvl1;
    [SerializeField] private Text text_Lvl2;
    [SerializeField] private Text text_Lvl3;
    [SerializeField] private Text text_sala;
    [SerializeField] private Text text_time1;
    [SerializeField] private Text text_time2;
    [SerializeField] private Text text_time3;
    [SerializeField] private Text[] Text_times /*= new Text[9]*/;
    /*public Text text_tiempo1_1;
    public Text text_tiempo1_2;
    public Text text_tiempo1_3;
    public Text text_tiempo2_1;
    public Text text_tiempo2_2;
    public Text text_tiempo2_3;
    public Text text_tiempo3_1;
    public Text text_tiempo3_2;
    public Text text_tiempo3_3;*/

    void Start()
    {
        /*Minutes_array = new int[] { PlayerPrefs.GetInt("tiempo1_1_min", 0), PlayerPrefs.GetInt("tiempo1_2_min", 0), PlayerPrefs.GetInt("tiempo1_3_min", 0), PlayerPrefs.GetInt("tiempo2_1_min", 0), PlayerPrefs.GetInt("tiempo2_2_min", 0), PlayerPrefs.GetInt("tiempo2_3_min", 0), PlayerPrefs.GetInt("tiempo3_1_min", 0), PlayerPrefs.GetInt("tiempo3_2_min", 0), PlayerPrefs.GetInt("tiempo3_3_min", 0) };
        Sec_array = new int[] { PlayerPrefs.GetInt("tiempo1_1_sec", 0), PlayerPrefs.GetInt("tiempo1_2_sec", 0), PlayerPrefs.GetInt("tiempo1_3_sec", 0), PlayerPrefs.GetInt("tiempo2_1_sec", 0), PlayerPrefs.GetInt("tiempo2_2_sec", 0), PlayerPrefs.GetInt("tiempo2_3_sec", 0), PlayerPrefs.GetInt("tiempo3_1_sec", 0), PlayerPrefs.GetInt("tiempo3_2_sec", 0), PlayerPrefs.GetInt("tiempo3_3_sec", 0) };
        Tenth_array = new int[] { (int)PlayerPrefs.GetFloat("tiempo1_1_ten", 0), (int)PlayerPrefs.GetFloat("tiempo1_2_ten", 0), (int)PlayerPrefs.GetFloat("tiempo1_3_ten", 0), (int)PlayerPrefs.GetFloat("tiempo2_1_ten", 0), (int)PlayerPrefs.GetFloat("tiempo2_2_ten", 0), (int)PlayerPrefs.GetFloat("tiempo2_3_ten", 0), (int)PlayerPrefs.GetFloat("tiempo3_1_ten", 0), (int)PlayerPrefs.GetFloat("tiempo3_2_ten", 0), (int)PlayerPrefs.GetFloat("tiempo3_3_ten", 0) };*/
        times_array = new int[] { PlayerPrefs.GetInt("tiempo1_1", 0), PlayerPrefs.GetInt("tiempo1_2", 0), PlayerPrefs.GetInt("tiempo1_3", 0), PlayerPrefs.GetInt("tiempo2_1", 0), PlayerPrefs.GetInt("tiempo2_2", 0), PlayerPrefs.GetInt("tiempo2_3", 0), PlayerPrefs.GetInt("tiempo3_1", 0), PlayerPrefs.GetInt("tiempo3_2", 0), PlayerPrefs.GetInt("tiempo3_3", 0) };

        val_language = PlayerPrefs.GetInt("Idioma", 0);
        change_text();

        if (times_array[0] != 0)
        {
            ButonLev2.interactable = true;
        }
        if (times_array[3] != 0)
        {
            ButonLev3.interactable = true;
        }
    }

    public void PlayGame(int scene)
    {
        GameObject.Find("Musica").GetComponent<AudioSource>().Pause();
        SceneManager.LoadScene(scene);
    }

    public void Volver()
    {
        SceneManager.LoadScene(0);
    }

    public void change_text()
    {
        int min, sec, ten;
        text_Lvl1.text = Level_array[val_language];
        text_Lvl2.text = Level_array[val_language];
        text_Lvl3.text = Level_array[val_language];
        text_sala.text = Sala_array[val_language];
        text_time1.text = Time_array[val_language];
        text_time2.text = Time_array[val_language];
        text_time3.text = Time_array[val_language];

        for (int i=0;i<9;i++)
        {
            if (times_array[i]==0)
            {
                Text_times[i].text = "";
            }
            else
            {
                min = times_array[i] / (60 * 100);
                sec = (times_array[i] - (min*(60 * 100)))/100;
                ten = (times_array[i] - (min * (60 * 100)) - (sec * 100));
                Text_times[i].text = min.ToString("00") + ":" + sec.ToString("00") + ":" + ten.ToString("00");
            }
        }
    }
}























