using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audios : MonoBehaviour
{
    // Start is called before the first frame update
    private static audios instance;
    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

}
