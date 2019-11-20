using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnController : MonoBehaviour
{

    public Transform puppetPrefab;

    bool isDead = false;
    public GameObject lastCheckpoint;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void die()
    {
        if (!isDead)
        {
            isDead = true;
            StartCoroutine(teleport(3f));
        }
    }

    private IEnumerator teleport(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        Destroy(transform.GetChild(0).gameObject);
        
        transform.position = lastCheckpoint.transform.position;

        GameObject instance =  Instantiate(puppetPrefab, transform.position, transform.rotation).gameObject;
        instance.transform.parent = transform;
    }

}
