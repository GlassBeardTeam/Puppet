using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TelonScript : MonoBehaviour
{
    public GameController gameController;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void stopAnimationUp()
    {
        gameController.startCounter();
        //Destroy(this.gameObject);
    }
    public void stopAnimationDown()
    {
        gameController.endGame();
    }
    public void startAnimationDown()
    {
        GetComponent<Animator>().SetBool("gameOver", true);
    }
}
