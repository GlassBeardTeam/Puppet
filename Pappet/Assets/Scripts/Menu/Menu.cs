﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    [SerializeField] private  Slider Slider_Effects;
    [SerializeField] private Slider Slider_Music;
    [SerializeField] private  AudioSource audio;
    [SerializeField] private AudioSource effect;
    string[] Player1_array = new string[] { "Jugar", "Play" };
    string[] Player2_array = new string[] { "Contacto", "Contact" };
    string[] Settings_array = new string[] { "Opciones", "Settings" };
    //string[] Language_array = new string[] { "Español", "English" };
    //string[] Back_array = new string[] { "Volver", "Back" };
    string[] Contact_array = new string[] { "Contacto", "Contact" };
    string[] Cinta_array = new string[] { "Coge tu\nentrada!!", "Get your\nticket!!" };
    string[] Level_array = new string[] { "Nivel", "Level" };
    string[] Sala_array = new string[] { "Sala", "Room" };
    string[] Music_array = new string[] { "Música", "Music" };
    string[] Effect_array = new string[] { "Efectos", "Effects" };
    string[] Present_array = new string[] { "presenta:", "presents:" };
    string[] Language_array = new string[] { "Idioma", "Language" };
    string[] Vestuario_array = new string[] { "Vestuario", "Dressing room" };
    public static int val_language;
    [SerializeField] private  Text text_1Player;
    [SerializeField] private  Text text_Settings_menu;
    [SerializeField] private Text text_Settings_settings;
    //public Text text_back;
    //public Text text_back2;
    //public Text text_back3;
    [SerializeField] private Text text_contact;
    [SerializeField] private Text text_contact2;
    [SerializeField] private Text text_cinta;
    //public Text text_Lvl1;
    //public Text text_Lvl2;
    //public Text text_Lvl3;
    //public Text text_sala;
    [SerializeField] private Text text_music;
    [SerializeField] private Text text_effect;
    [SerializeField] private Text text_present;
    [SerializeField] private Text text_language;
    [SerializeField] private Text text_vestuario;
    //Boton idiomas
    [SerializeField] private Sprite Flag1;
    [SerializeField] private Sprite Flag2;
    [SerializeField] private Button btn_language;
    [SerializeField] private Sprite[] ImageFlag_array;
    private static bool musica_iniciada=false;

    public void change_scene(int scene)
    {
        SceneManager.LoadScene(scene);
    }

    /*
    public void PlayGame(int scene)
    {
        SceneManager.LoadScene(scene);
    }
    */
    public void Start()
    {
        if (!musica_iniciada)
        {
            PlayerPrefs.SetFloat("Volumen", 1.0f);
            PlayerPrefs.SetFloat("Slider_music", 1.0f);
            audio.Play(0);
            musica_iniciada = true;
        }
        Slider_Effects.value = PlayerPrefs.GetFloat("Volumen", 1.0f);
        Slider_Music.value = PlayerPrefs.GetFloat("Slider_music", 1.0f);
        ImageFlag_array = new Sprite[] { Flag1, Flag2 };
        val_language = PlayerPrefs.GetInt("Idioma", 0);
        change_text();
    }

    public void change_language()
    {
        val_language++;
        if(val_language> Player1_array.Length-1)
        {
            val_language = 0;
        }
        PlayerPrefs.SetInt("Idioma", val_language);
        change_text();
    }

    public void change_text()
    {
        //btn_language.GetComponent<Image>().sprite =  Resources.Load<Sprite>("Assets/Items/flagUK");
        btn_language.GetComponent<Image>().sprite = ImageFlag_array[val_language];
        text_1Player.text = Player1_array[val_language];
        text_Settings_menu.text = Settings_array[val_language];
        text_Settings_settings.text = Settings_array[val_language];
        text_contact.text = Contact_array[val_language];
        text_contact2.text = Contact_array[val_language];
        text_cinta.text = Cinta_array[val_language];
        /*text_Lvl1.text = Level_array[val_language];
        text_Lvl2.text = Level_array[val_language];
        text_Lvl3.text = Level_array[val_language];
        text_sala.text = Sala_array[val_language];*/
        text_music.text = Music_array[val_language];
        text_effect.text = Effect_array[val_language];
        text_present.text = Present_array[val_language];
        text_language.text = Language_array[val_language];
        text_vestuario.text = Vestuario_array[val_language];
    }

    public void change_volume()
    {
        PlayerPrefs.SetFloat("Volumen", Slider_Effects.value);
        effect.volume = Slider_Effects.value;
        if (!effect.isPlaying)
        {
            effect.Play();
        }
    }

    public void change_music()
    {
        PlayerPrefs.SetFloat("Slider_music", Slider_Music.value);
    }

    public void pressButton()
    {
        if (!effect.isPlaying)
        {
            effect.Play();
        }
    }
    public void open_web(string web)
    {
        Application.ExternalEval("window.open(\"" + web + "\")");
    }
}
