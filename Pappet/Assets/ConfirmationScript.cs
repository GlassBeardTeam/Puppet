using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConfirmationScript : MonoBehaviour
{
    public StickerIndexer sticker;
    public MenuController controller;

    private void Start()
    {
        switch (PlayerPrefs.GetInt("Idioma"))
        {
            case 0:
                transform.GetChild(0).gameObject.GetComponent<Text>().text = "¿Quieres desbloquear este sticker por              ?";
                break;
            case 1:
                transform.GetChild(0).gameObject.GetComponent<Text>().text = "Do you want to unlock this sticker for              ?";
                break;
        }
        
    }
    private void Update()
    {
        
    }

    public void accept()
    {
        controller.acceptConfirmationPanel(sticker);
    }
    public void decline()
    {
        controller.declineConfirmationPanel();
    }
}
