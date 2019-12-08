using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogueESP;
    public Dialogue dialogueENG;
    private bool started = false;

    public void TriggerDialogue()
    {
        switch (PlayerPrefs.GetInt("Idioma"))
        {
            case 0:
                FindObjectOfType<DialogueManager>().StartDialogue(dialogueESP);
                break;
            case 1:
                FindObjectOfType<DialogueManager>().StartDialogue(dialogueENG);
                break;
            default:
                FindObjectOfType<DialogueManager>().StartDialogue(dialogueENG);
                break;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!started)
        {
            started = true;
            TriggerDialogue();
        }
    }
}
