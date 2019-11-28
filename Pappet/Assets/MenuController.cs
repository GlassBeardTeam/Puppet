using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;


public enum Pieza
{
    CABEZA,
    TORSO,
    BRAZOIZQ,
    MANOIZQ,
    BRAZODER,
    MANODER,
    PIERNAIZQ,
    PIEIZQ,
    PIERNADER,
    PIEDER

}

public class MenuController : MonoBehaviour
{

    public GridLayoutGroup grid;

    public VerticalLayoutGroup group;

    public Button button;

    public Texture2D[] TorsoStickers;
    public Texture2D[] BrazoIzqStickers;
    public Texture2D[] BrazoDerStickers;
    public Texture2D[] ManoIzqStickers;
    public Texture2D[] ManoDerStickers;
    public Texture2D[] PiernaIzqStickers;
    public Texture2D[] PiernaDerStickers;
    public Texture2D[] PieIzqStickers;
    public Texture2D[] PieDerStickers;  

    List<Texture2D[]> stickerList =  new List<Texture2D[]>();

    public Texture2D[] CabezaStickers;
    // Start is called before the first frame update
    void Start()
    {
        //CabezaStickers = AssetDatabase.LoadAllAssetsAtPath("Assets/Puppets/Puppet1/Customization/Stickers");
        //TorsoStickers = AssetDatabase.LoadAllAssetsAtPath("Assets/Puppets/Puppet1/Customization/Stickers");
        //BrazoIzqStickers = AssetDatabase.LoadAllAssetsAtPath("Assets/Puppets/Puppet1/Customization/Stickers");
        //BrazoDerStickers = AssetDatabase.LoadAllAssetsAtPath("Assets/Puppets/Puppet1/Customization/Stickers");
        //ManoIzqStickers = AssetDatabase.LoadAllAssetsAtPath("Assets/Puppets/Puppet1/Customization/Stickers");
        //ManoDerStickers = AssetDatabase.LoadAllAssetsAtPath("Assets/Puppets/Puppet1/Customization/Stickers");T
        //PiernaIzqStickers = AssetDatabase.LoadAllAssetsAtPath("Assets/Puppets/Puppet1/Customization/Stickers");
        //PiernaDerStickers = AssetDatabase.LoadAllAssetsAtPath("Assets/Puppets/Puppet1/Customization/Stickers");
        //PieIzqStickers = AssetDatabase.LoadAllAssetsAtPath("Assets/Puppets/Puppet1/Customization/Stickers");
        //PieIzqStickers = AssetDatabase.LoadAllAssetsAtPath("Assets/Puppets/Puppet1/Customization/Stickers");

        //stickerList.Add(CabezaStickers);

        //stickerList.Add(TorsoStickers);

        //stickerList.Add(BrazoIzqStickers);

        //stickerList.Add(BrazoDerStickers);

        //stickerList.Add(ManoIzqStickers);

        //stickerList.Add(ManoDerStickers);

        //stickerList.Add(PiernaIzqStickers);

        //stickerList.Add(PiernaDerStickers);

        //stickerList.Add(PieIzqStickers);

        //stickerList.Add(PieIzqStickers);



        showAll();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void showSet(Pieza pieza)
    {
        clearGrid();
        switch (pieza)
        {
            case Pieza.CABEZA:
                foreach (Texture2D tex in CabezaStickers)
                {
                    addToGrid(tex);
                }
                break;
            case Pieza.BRAZODER:
                foreach (Texture2D tex in BrazoDerStickers)
                {
                    addToGrid(tex);
                }
                break;
            case Pieza.BRAZOIZQ:
                foreach (Texture2D tex in BrazoIzqStickers)
                {
                    addToGrid(tex);
                }
                break;
            case Pieza.MANODER:
                foreach (Texture2D tex in ManoDerStickers)
                {
                    addToGrid(tex);
                }
                break;
            case Pieza.MANOIZQ:
                foreach (Texture2D tex in ManoIzqStickers)
                {
                    addToGrid(tex);
                }
                break;
            case Pieza.PIEDER:
                foreach (Texture2D tex in PieDerStickers)
                {
                    addToGrid(tex);
                }
                break;
            case Pieza.PIEIZQ:
                foreach (Texture2D tex in PieIzqStickers)
                {
                    addToGrid(tex);
                }
                break;
            case Pieza.PIERNADER:
                foreach (Texture2D tex in PiernaDerStickers)
                {
                    addToGrid(tex);
                }
                break;
            case Pieza.PIERNAIZQ:
                foreach (Texture2D tex in PiernaIzqStickers)
                {
                    addToGrid(tex);
                }
                break;
            case Pieza.TORSO:
                foreach (Texture2D tex in TorsoStickers)
                {
                    addToGrid(tex);
                }
                break;
        }
    }
    public void showAll()
    {
        
        for(int i = 0; i < CabezaStickers.Length; i++)
        {
            VerticalLayoutGroup vlg = Instantiate(group, grid.transform);
            addToGroup(TorsoStickers[i], vlg);
            addToGroup(BrazoIzqStickers[i], vlg);
            addToGroup(BrazoDerStickers[i], vlg);
            addToGroup(ManoIzqStickers[i], vlg);
            addToGroup(ManoDerStickers[i], vlg);
            addToGroup(PiernaIzqStickers[i], vlg);
            addToGroup(PiernaDerStickers[i], vlg);
            addToGroup(PieIzqStickers[i], vlg);
            addToGroup(PieDerStickers[i], vlg);
            vlg.transform.parent = grid.transform;
        }

    }

    private void addToGroup(Texture2D tex, VerticalLayoutGroup g)
    {
        Button buttonInstance = Instantiate(button, g.transform) as Button;
        buttonInstance.GetComponent<Image>().sprite = Sprite.Create(tex,
        new Rect(0, 0, tex.width, tex.height),
        new Vector2(0.5f, 0.5f),
        40); ;
    }

    private void addToGrid(Texture2D tex)
    {
        Button buttonInstance = Instantiate(button, grid.transform) as Button;
        buttonInstance.GetComponent<Image>().sprite = Sprite.Create(tex,
        new Rect(0, 0, tex.width, tex.height),
        new Vector2(0.5f, 0.5f),
        40); ;
    }

    private void clearGrid()
    {
        foreach (Transform child in grid.transform)
        {
            GameObject.Destroy(child.gameObject);
        }
    }

    public void selectBodyPart(int pieza)
    {
        showSet((Pieza)pieza);
    }
}
