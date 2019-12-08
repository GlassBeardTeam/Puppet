using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{

    public static bool GameIsPaused;

    public GameObject pauseMenuUI;

    string[] Pause_array = new string[] { "Pausa", "Pause" };
    string[] Continue_array = new string[] { "Continuar", "Continue" };
    string[] Exit_array = new string[] { "Salir", "Exit" };

    [SerializeField] private Text text_pause;
    [SerializeField] private Text text_continue;
    [SerializeField] private Text text_exit;

    private void Start()
    {
        text_pause.text = Pause_array[PlayerPrefs.GetInt("Idioma", 0)];
        text_continue.text = Continue_array[PlayerPrefs.GetInt("Idioma", 0)];
        text_exit.text = Exit_array[PlayerPrefs.GetInt("Idioma", 0)];
        GameIsPaused = false;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void QuitLevel()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
        GameObject.Find("Musica").GetComponent<AudioSource>().Play();
        //Debug.Log("Quitting level...");
        SceneManager.LoadScene("selector_nivel");
    }
}
