using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StickerIndexer : MonoBehaviour
{
    MenuController menuController;
    Image image;

    public int SetIndex;
    public int PartIndex;
    public bool Locked;

    // Start is called before the first frame update
    void Start()
    {
        menuController = GameObject.FindGameObjectWithTag("CustomizationController").GetComponent<MenuController>();
        image = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void selectSticker()
    {
        if(menuController.selectSticker(SetIndex, PartIndex, Locked))
            image.color = Color.white;
    }
}
