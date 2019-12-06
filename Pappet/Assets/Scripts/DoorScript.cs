using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;


public class DoorScript : MonoBehaviour
{
    
    AudioSource GoalEffect;
    private bool endLevel = false;

    public GameController gameController;

    Stack<GameObject> gears = new Stack<GameObject>();
    public bool locked = true;
    // Start is called before the first frame update
    void Start()
    {
        GoalEffect = GameObject.FindGameObjectWithTag("GoalEffect").GetComponent<AudioSource>();
        GoalEffect.volume = PlayerPrefs.GetFloat("Volumen", 1.0f);

        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(false);
            gears.Push(child.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
   private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "PuppetPart" && !locked)
        {
            if (!GoalEffect.isPlaying && !endLevel)
            {
                GoalEffect.Play();
                endLevel = true;
            }
            gameController.closeTelon();
        }
    }

    public void showGear()
    {
        gears.Pop().SetActive(true);

        if(gears.Count == 0)
        {
            //abrir puerta
        }
    }
}
