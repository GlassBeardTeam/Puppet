using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickerIndexer : MonoBehaviour
{
    MenuController menuController;

    public int SetIndex;
    public int PartIndex;

    // Start is called before the first frame update
    void Start()
    {
        menuController = GameObject.FindGameObjectWithTag("CustomizationController").GetComponent<MenuController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void selectSticker()
    {
        menuController.selectSticker(SetIndex, PartIndex);
    }
}
