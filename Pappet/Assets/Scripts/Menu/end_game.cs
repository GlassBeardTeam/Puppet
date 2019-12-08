using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class end_game : MonoBehaviour
{
    public static int val_language;
    string[] Score_array = new string[] { "Puntuación", "Score" };
    [SerializeField] private Text text_Score;
    [SerializeField] private Text text_time;
    [SerializeField] private Text text_numCoils;
    [SerializeField] private int[] times_array;
    [SerializeField] private string[] times_prefs;

    // Start is called before the first frame update
    void Start()
    {
        GameObject.Find("Musica").GetComponent<AudioSource>().Play();

        times_array = new int[] { PlayerPrefs.GetInt("tiempo1_1", 0), PlayerPrefs.GetInt("tiempo1_2", 0), PlayerPrefs.GetInt("tiempo1_3", 0), PlayerPrefs.GetInt("tiempo2_1", 0), PlayerPrefs.GetInt("tiempo2_2", 0), PlayerPrefs.GetInt("tiempo2_3", 0), PlayerPrefs.GetInt("tiempo3_1", 0), PlayerPrefs.GetInt("tiempo3_2", 0), PlayerPrefs.GetInt("tiempo3_3", 0) };
        times_prefs = new string[] { "tiempo1_1", "tiempo1_2", "tiempo1_3", "tiempo2_1", "tiempo2_2", "tiempo2_3", "tiempo3_1", "tiempo3_2", "tiempo3_3" };

        int tiempo_aux2, tiempo_aux = 0;
        bool usado = false;

        //Actualiza array del ranking
        if (!(PlayerPrefs.GetInt("tiempo_act", -1) == -1))
        {
            for (int i = 0; i < times_array.Length; i++)//Recorre los arrays de tiempos
            {
                if ((i / 3) + 1 == PlayerPrefs.GetInt("level_play", -1))//Selecciona las posiciones a mirar, 3 es el numero de puntuaciones guardadas
                {
                    if (times_array[i] > PlayerPrefs.GetInt("tiempo_act") && (tiempo_aux == 0))
                    {
                        tiempo_aux = times_array[i];
                        times_array[i] = PlayerPrefs.GetInt("tiempo_act");
                        usado = true;
                    }
                    else if (!(tiempo_aux == 0))
                    {
                        tiempo_aux2 = times_array[i];
                        times_array[i] = tiempo_aux;
                        tiempo_aux = tiempo_aux2;
                    }
                    else if (times_array[i] == 0 && usado == false)
                    {
                        times_array[i] = PlayerPrefs.GetInt("tiempo_act");
                        usado = true;
                    }
                }
            }
        }
        //Actualiza el ranking
        for (int i = 0; i < times_prefs.Length; i++)//Recorre los arrays de tiempos
        {
            PlayerPrefs.SetInt(times_prefs[i], times_array[i]);
        }

        //Actualiza los numeros de bobinas del jugador
        int player_coils = PlayerPrefs.GetInt("coil", 0);
        player_coils += PlayerPrefs.GetInt("coil_level", 0);
        PlayerPrefs.SetInt("coil_player", player_coils);

        val_language = PlayerPrefs.GetInt("Idioma", 0);
        change_text();
    }
    public void continuar()
    {
        SceneManager.LoadScene(1);
    }

    public void vestuario()
    {
        SceneManager.LoadScene(6);
    }

    public void change_text()
    {
        text_numCoils.text = "+" + PlayerPrefs.GetInt("coil_level", 0) + " = " + PlayerPrefs.GetInt("coil", 0);
        text_Score.text = Score_array[val_language];
        int min = PlayerPrefs.GetInt("tiempo_act") / (60 * 100);
        int sec = (PlayerPrefs.GetInt("tiempo_act") - (min * (60 * 100))) / 100;
        int ten = (PlayerPrefs.GetInt("tiempo_act") - (min * (60 * 100)) - (sec * 100));
        text_time.text = min.ToString("00") + ":" + sec.ToString("00") + ":" + ten.ToString("00");
    }
}
