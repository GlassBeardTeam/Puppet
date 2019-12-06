using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfirmationScript : MonoBehaviour
{
    public StickerIndexer sticker;
    public MenuController controller;

    private void Start()
    {
        
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
