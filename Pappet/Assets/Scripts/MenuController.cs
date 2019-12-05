using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

using SaveData;



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

    public CartelEndGame cartel;

    public GameObject puppet;

    public GridLayoutGroup grid;

    public VerticalLayoutGroup group;

    public Button button;

    public Texture2D[] CabezaStickers;
    public Texture2D[] TorsoStickers;
    public Texture2D[] BrazoIzqStickers;
    public Texture2D[] BrazoDerStickers;
    public Texture2D[] ManoIzqStickers;
    public Texture2D[] ManoDerStickers;
    public Texture2D[] PiernaIzqStickers;
    public Texture2D[] PiernaDerStickers;
    public Texture2D[] PieIzqStickers;
    public Texture2D[] PieDerStickers;

    public Dictionary<Pieza, Texture2D[]> stickerDict = new Dictionary<Pieza, Texture2D[]>();

    StickerData stickerData;

    int PRICE = 10;

    private void Awake()
    {
        Load();


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

        if (grid != null)
        {
            showAll();
        }

        if (puppet != null)
        {
            //Ponemos al puppet con las pegatinas que deberia tener
            selectSticker(PlayerPrefs.GetInt(((int)Pieza.CABEZA).ToString(), 0), (int)Pieza.CABEZA, false);
            selectSticker(PlayerPrefs.GetInt(((int)Pieza.TORSO).ToString(), 0), (int)Pieza.TORSO, false);
            selectSticker(PlayerPrefs.GetInt(((int)Pieza.BRAZOIZQ).ToString(), 0), (int)Pieza.BRAZOIZQ, false);
            selectSticker(PlayerPrefs.GetInt(((int)Pieza.BRAZODER).ToString(), 0), (int)Pieza.BRAZODER, false);
            selectSticker(PlayerPrefs.GetInt(((int)Pieza.MANOIZQ).ToString(), 0), (int)Pieza.MANOIZQ, false);
            selectSticker(PlayerPrefs.GetInt(((int)Pieza.MANODER).ToString(), 0), (int)Pieza.MANODER, false);
            selectSticker(PlayerPrefs.GetInt(((int)Pieza.PIERNAIZQ).ToString(), 0), (int)Pieza.PIERNAIZQ, false);
            selectSticker(PlayerPrefs.GetInt(((int)Pieza.PIERNADER).ToString(), 0), (int)Pieza.PIERNADER, false);
            selectSticker(PlayerPrefs.GetInt(((int)Pieza.PIEIZQ).ToString(), 0), (int)Pieza.PIEIZQ, false);
            selectSticker(PlayerPrefs.GetInt(((int)Pieza.PIEDER).ToString(), 0), (int)Pieza.PIEDER, false);
        }
    }
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
        140);
        buttonInstance.GetComponent<Image>().sprite = sprite;
        buttonInstance.GetComponent<Image>().SetNativeSize();
        buttonInstance.GetComponent<StickerIndexer>().SetIndex = setIndex;
        buttonInstance.GetComponent<StickerIndexer>().PartIndex = pieza;
        buttonInstance.GetComponent<StickerIndexer>().Locked = stickerData.isLocked(pieza, setIndex);
        if (stickerData.isLocked(pieza, setIndex))
        {
            buttonInstance.GetComponent<Image>().color = Color.black;
        }
        else
        {
            buttonInstance.GetComponent<Image>().color = Color.white;
        }
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
        buttonInstance.GetComponent<StickerIndexer>().Locked = stickerData.isLocked(pieza, setIndex);
        if (stickerData.isLocked(pieza, setIndex))
        {
            buttonInstance.GetComponent<Image>().color = Color.black;
        }
        else
        {
            buttonInstance.GetComponent<Image>().color = Color.white;
        }
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
    public bool selectSticker(int setIndex, int pieza, bool locked)
    {
        if (locked) {
            int coil = PlayerPrefs.GetInt("coil", 0);
            if(coil >= PRICE)
            {
                PlayerPrefs.SetInt("coil", coil - PRICE);
                cartel.updateText();
                stickerData.unlockSticker(pieza, setIndex);
                Save();
            }
            else
            {
                return false;
            }
            
        }
        Texture2D tex = stickerDict[(Pieza)pieza][setIndex];
        puppet.transform.GetChild(pieza).GetComponent<Image>().sprite = Sprite.Create(tex,
                                                        new Rect(0, 0, tex.width, tex.height),
                                                        new Vector2(0.5f, 0.5f),
                                                        40);
        PlayerPrefs.SetInt(pieza.ToString(), setIndex);

        return true;

    }
     public void volver()
    {
        SceneManager.LoadScene(0);
        Save();
    }

    public void Load()
    {
        if (File.Exists(Application.persistentDataPath + "/stickers.gd"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/stickers.gd", FileMode.Open);
            stickerData = (StickerData)bf.Deserialize(file);
            file.Close();
        }
        else
        {
            stickerData = new StickerData(CabezaStickers.Length);
        }

    }
    public void Save()
    {
            BinaryFormatter bf = new BinaryFormatter();
            //Application.persistentDataPath is a string, so if you wanted you can put that into debug.log if you want to know where save games are located
            FileStream file = File.Create(Application.persistentDataPath + "/stickers.gd"); //you can call it anything you want
            bf.Serialize(file, stickerData);
            file.Close();
    }
}
