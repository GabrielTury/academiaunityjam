using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    PlayerScript playerScript;

    public static DialogueManager instance;

    public TextMeshProUGUI dialogueText;
    public GameObject dialoguePrefab;

    private Queue<string> sentences;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        sentences = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        dialoguePrefab.SetActive(true);

        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }
        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            DialogueTrigger.EndCrossfadeDialogue = true;
            return;
        }
        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(UpdateDialogue(sentence));
    }

    IEnumerator UpdateDialogue(string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(0.01f);
        }
    }

    private void EndDialogue()
    {
        dialoguePrefab.SetActive(false);
        ResumePlayer(playerScript);
    }
    public void GetPlayerScript(PlayerScript playableCharacter)
    {
        playerScript = playableCharacter;
    }
    public void ResumePlayer(PlayerScript playableCharacter)
    {
        playableCharacter.maxSpeed = playableCharacter.GetMaxSpeed0;
    }
}