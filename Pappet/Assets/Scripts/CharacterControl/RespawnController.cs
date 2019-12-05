using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class RespawnController : MonoBehaviour
{
    AudioSource DeathEffect;
    AudioSource ReviveEffect;

    public Transform puppetPrefab;
    public TouchControls inputHandler;
    bool isDead = false;
    GameObject lastCheckpoint;
    // Start is called before the first frame update
    void Start()
    {
        DeathEffect = GameObject.FindGameObjectWithTag("DeathEffect").GetComponent<AudioSource>();
        ReviveEffect = GameObject.FindGameObjectWithTag("ReviveEffect").GetComponent<AudioSource>();
        DeathEffect.volume = PlayerPrefs.GetFloat("Volumen", 1.0f);
        ReviveEffect.volume = PlayerPrefs.GetFloat("Volumen", 1.0f);

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void setLastCheckpoint(GameObject checkpoint)
    {
        lastCheckpoint = checkpoint;
    }

    public void die()
    {
        if (!isDead)
        {
            if (!DeathEffect.isPlaying)
            {
                DeathEffect.Play();
            }
            Debug.Log("Dead");
            isDead = true;
            StartCoroutine(teleport(3f));
        }
    }

    private IEnumerator teleport(float seconds)
    {
        if (lastCheckpoint != null)
        {
            yield return new WaitForSeconds(seconds);
            Destroy(transform.GetChild(0).gameObject);

            transform.position = lastCheckpoint.transform.position;

            GameObject instance = Instantiate(puppetPrefab, transform.position, transform.rotation).gameObject;
            instance.transform.parent = transform;
            instance.GetComponent<Puppet>().inputHandler = inputHandler;

            if (!ReviveEffect.isPlaying)
            {
                ReviveEffect.Play();
            }
            Debug.Log("Respawn");

            isDead = false;
        }
    }

}
