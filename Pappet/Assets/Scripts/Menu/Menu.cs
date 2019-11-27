using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    string[] Player1_array = new string[] { "1 Jugador", "1 Player" };
    string[] Player2_array = new string[] { "Contacto", "Contact" };
    string[] Settings_array = new string[] { "Opciones", "Settings" };
    //string[] Language_array = new string[] { "Español", "English" };
    string[] Back_array = new string[] { "Volver", "Back" };
    string[] Contact_array = new string[] { "Contacto", "Contact" };
    public static int val_language = 0;
    public Text text_1Player;
    public Text text_2Player;
    public Text text_Settings_menu;
    public Text text_Settings_settings;
    public Text text_back;
    public Text text_back2;
    public Text text_contact;
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Debug.Log(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void change_language()
    {
        val_language++;
        if(val_language> Player1_array.Length-1)
        {
            val_language = 0;
        }
        Debug.Log(Player1_array.Length);
        text_1Player.text = Player1_array[val_language];
        text_2Player.text = Player2_array[val_language];
        text_Settings_menu.text = Settings_array[val_language];
        text_Settings_settings.text = Settings_array[val_language];
        text_back.text = Back_array[val_language];
        text_back2.text = Back_array[val_language];
        text_contact.text = Contact_array[val_language];
    }
}
