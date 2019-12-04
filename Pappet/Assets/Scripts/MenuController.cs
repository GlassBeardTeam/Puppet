using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public enum Pieza
{
    CABEZA,
    TORSO,
    BRAZOIZQ,
    BRAZODER,
    MANOIZQ,
    MANODER,
    PIERNAIZQ,
    PIERNADER,
    PIEIZQ,
    PIEDER

}

public class MenuController : MonoBehaviour
{

    public GameObject puppet;

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

    Dictionary<Pieza, Texture2D[]> stickerDict = new Dictionary<Pieza, Texture2D[]>();

    public Texture2D[] CabezaStickers;
    // Start is called before the first frame update
    void Start()
    {
        //CabezaStickers[0] = (UnityEditor.AssetDatabase.LoadAssetAtPath("Assets/Puppets/Puppet1/Customization/Stickers/", typeof(Texture2D))) as Texture2D;
        //TorsoStickers = AssetDatabase.LoadAllAssetsAtPath("Assets/Puppets/Puppet1/Customization/Stickers");
        //BrazoIzqStickers = AssetDatabase.LoadAllAssetsAtPath("Assets/Puppets/Puppet1/Customization/Stickers");
        //BrazoDerStickers = AssetDatabase.LoadAllAssetsAtPath("Assets/Puppets/Puppet1/Customization/Stickers");
        //ManoIzqStickers = AssetDatabase.LoadAllAssetsAtPath("Assets/Puppets/Puppet1/Customization/Stickers");
        //ManoDerStickers = AssetDatabase.LoadAllAssetsAtPath("Assets/Puppets/Puppet1/Customization/Stickers");T
        //PiernaIzqStickers = AssetDatabase.LoadAllAssetsAtPath("Assets/Puppets/Puppet1/Customization/Stickers");
        //PiernaDerStickers = AssetDatabase.LoadAllAssetsAtPath("Assets/Puppets/Puppet1/Customization/Stickers");
        //PieIzqStickers = AssetDatabase.LoadAllAssetsAtPath("Assets/Puppets/Puppet1/Customization/Stickers");
        //PieIzqStickers = AssetDatabase.LoadAllAssetsAtPath("Assets/Puppets/Puppet1/Customization/Stickers");

        stickerDict.Add(Pieza.CABEZA, CabezaStickers);
        stickerDict.Add(Pieza.TORSO, TorsoStickers);
        stickerDict.Add(Pieza.BRAZOIZQ, BrazoIzqStickers);
        stickerDict.Add(Pieza.BRAZODER, BrazoDerStickers);
        stickerDict.Add(Pieza.MANOIZQ, ManoIzqStickers);
        stickerDict.Add(Pieza.MANODER, ManoDerStickers);
        stickerDict.Add(Pieza.PIERNAIZQ, PiernaIzqStickers);
        stickerDict.Add(Pieza.PIERNADER, PiernaDerStickers);
        stickerDict.Add(Pieza.PIEIZQ, PieIzqStickers);
        stickerDict.Add(Pieza.PIEDER, PieIzqStickers);

        showAll();

        //Ponemos al puppet con las pegatinas que deberia tener
        selectSticker(PlayerPrefs.GetInt(((int)Pieza.CABEZA, 0).ToString()), (int)Pieza.CABEZA);
        selectSticker(PlayerPrefs.GetInt(((int)Pieza.TORSO, 0).ToString()), (int)Pieza.TORSO);
        selectSticker(PlayerPrefs.GetInt(((int)Pieza.BRAZOIZQ, 0).ToString()), (int)Pieza.BRAZOIZQ);
        selectSticker(PlayerPrefs.GetInt(((int)Pieza.BRAZODER, 0).ToString()), (int)Pieza.BRAZODER);
        selectSticker(PlayerPrefs.GetInt(((int)Pieza.MANOIZQ, 0).ToString()), (int)Pieza.MANOIZQ);
        selectSticker(PlayerPrefs.GetInt(((int)Pieza.MANODER, 0).ToString()), (int)Pieza.MANODER);
        selectSticker(PlayerPrefs.GetInt(((int)Pieza.PIERNAIZQ, 0).ToString()), (int)Pieza.PIERNAIZQ);
        selectSticker(PlayerPrefs.GetInt(((int)Pieza.PIERNADER, 0).ToString()), (int)Pieza.PIERNADER);
        selectSticker(PlayerPrefs.GetInt(((int)Pieza.PIEIZQ, 0).ToString()), (int)Pieza.PIEIZQ);
        selectSticker(PlayerPrefs.GetInt(((int)Pieza.PIEDER, 0).ToString()), (int)Pieza.PIEDER);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void showSet(Pieza pieza)
    {
        clearGrid();
        
        for(int i = 0; i < stickerDict[pieza].Length; i++)
        {
            addToGrid((int)pieza, i, stickerDict[pieza][i]);
        }
    }
    public void showAll()
    {

        clearGrid();

        for (int i = 0; i < CabezaStickers.Length; i++)
        {
            VerticalLayoutGroup vlg = Instantiate(group, grid.transform);
            addToGroup(0, i, CabezaStickers[i], vlg);
            addToGroup(1, i, TorsoStickers[i], vlg);
            addToGroup(2, i, BrazoIzqStickers[i], vlg);
            addToGroup(3, i, BrazoDerStickers[i], vlg);
            addToGroup(4, i, ManoIzqStickers[i], vlg);
            addToGroup(5, i, ManoDerStickers[i], vlg);
            addToGroup(6, i, PiernaIzqStickers[i], vlg);
            addToGroup(7, i, PiernaDerStickers[i], vlg);
            addToGroup(8, i, PieIzqStickers[i], vlg);
            addToGroup(9, i, PieDerStickers[i], vlg);

            vlg.transform.parent = grid.transform;
        }

    }

    private void addToGroup(int pieza, int setIndex, Texture2D tex, VerticalLayoutGroup g)
    {
        Button buttonInstance = Instantiate(button, g.transform) as Button;
        Sprite sprite = Sprite.Create(tex,
        new Rect(0, 0, tex.width, tex.height),
        new Vector2(0.5f, 0.5f),
        100);
        buttonInstance.GetComponent<Image>().sprite = sprite;
        buttonInstance.GetComponent<Image>().SetNativeSize();
        buttonInstance.GetComponent<StickerIndexer>().SetIndex = setIndex;
        buttonInstance.GetComponent<StickerIndexer>().PartIndex = pieza;
    }

    private void addToGrid(int pieza, int setIndex, Texture2D tex)
    {
        Button buttonInstance = Instantiate(button, grid.transform) as Button;
        buttonInstance.GetComponent<Image>().sprite = Sprite.Create(tex,
        new Rect(0, 0, tex.width, tex.height),
        new Vector2(0.5f, 0.5f),
        40);
        buttonInstance.GetComponent<StickerIndexer>().SetIndex = setIndex;
        buttonInstance.GetComponent<StickerIndexer>().PartIndex = pieza;
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
    public void selectSticker(int setIndex, int pieza)
    {
        Texture2D tex = stickerDict[(Pieza)pieza][setIndex];
        puppet.transform.GetChild(pieza).GetComponent<Image>().sprite = Sprite.Create(tex,
                                                        new Rect(0, 0, tex.width, tex.height),
                                                        new Vector2(0.5f, 0.5f),
                                                        40);
        PlayerPrefs.SetInt(pieza.ToString(), setIndex);
    }
}
