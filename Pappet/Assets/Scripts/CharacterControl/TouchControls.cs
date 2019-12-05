using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchControls : MonoBehaviour
{
    public float horizontalInput;
    public float verticalInput;
    // Update is called once per frame
    public void handleHorizontalInput(int value)
    {
        horizontalInput += value;
        horizontalInput = Mathf.Clamp(horizontalInput, -1, 1);
    }

    public void handleVerticalInput(int value)
    {
        verticalInput += value;
        verticalInput = Mathf.Clamp(verticalInput, -1, 1);
    }

    void Update()
    {
        for(int i = 0; i< Input.touchCount; i++)
        {
            Touch touch = Input.GetTouch(i);
            switch (touch.phase)
            {
                
                case TouchPhase.Began:
                case TouchPhase.Moved:
                    if (touch.position.x < Screen.width / 3)
                    {
                        handleHorizontalInput(-1);
                    }
                    else if (touch.position.x > Screen.width * 2 / 3)
                    {
                        handleHorizontalInput(1);
                    }
                    else if (touch.position.x > Screen.width / 3 && touch.position.x < Screen.width * 2 / 3)
                    {
                        handleVerticalInput(-1);
                    }
                    break;

                case TouchPhase.Ended:
                case TouchPhase.Canceled:
                    if (touch.position.x < Screen.width / 3)
                    {
                        handleHorizontalInput(1);
                    }
                    else if (touch.position.x > Screen.width * 2 / 3)
                    {
                        handleHorizontalInput(-1);
                    }
                    else if (touch.position.x > Screen.width / 3 && touch.position.x < Screen.width * 2 / 3)
                    {
                        handleVerticalInput(1);
                    }
                    break;
            }
        }
    }
}
