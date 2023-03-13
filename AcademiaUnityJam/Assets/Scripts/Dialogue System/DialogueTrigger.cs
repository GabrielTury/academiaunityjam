using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    public static bool EndCrossfadeDialogue = true;

    public void TriggerDialogue()
    {
        EndCrossfadeDialogue = false;
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {

            DialogueManager.instance.GetPlayerScript(collision.gameObject.GetComponent<PlayerScript>());
            TriggerDialogue();
            Destroy(gameObject);
        }
    }
}

