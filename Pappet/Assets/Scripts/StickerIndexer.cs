using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StickerIndexer : MonoBehaviour
{
    public MenuController menuController;
    Image image;

    public int SetIndex;
    public int PartIndex;
    public bool Locked;

    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void selectSticker()
    {
        if (Locked)
        {
            menuController.openConfirmationPanel(this);
        }
        else
        {
            menuController.selectSticker(SetIndex, PartIndex, Locked);
        }
    }

    public void show()
    {
        image.color = Color.white;
    }
}
