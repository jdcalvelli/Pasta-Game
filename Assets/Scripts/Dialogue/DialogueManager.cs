using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class DialogueManager : MonoBehaviour
{

    public Text NameText;
    public Text DialogueText;

    public GameObject DialogueBox;

    private Queue<string> sentences; //restrictive list, first in first out
    
    void Start()
    {
        sentences = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        DialogueBox.GetComponent<RectTransform>().DOMoveY(-3f, 1f).SetEase(Ease.InOutSine);

        Debug.Log("starting conversation with " + dialogue.name);

        NameText.text = dialogue.name;
        
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
            return;
        }

        string sentence = sentences.Dequeue();
        Debug.Log(sentence);
        DialogueText.text = sentence; 
    }

    public void EndDialogue()
    {
        Debug.Log("end conversation");

        DialogueBox.GetComponent<RectTransform>().DOMoveY(-8f, 1f).SetEase(Ease.InOutSine);
    }

}
