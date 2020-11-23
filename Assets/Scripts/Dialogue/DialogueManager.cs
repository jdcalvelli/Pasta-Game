using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class DialogueManager : MonoBehaviour
{


    public GameManager GameManager;

    public GameObject Ingredients;

    public GameObject BehindDialogueBox;

    public Text NameText;
    public Text DialogueText;

    public GameObject DialogueBox;

    private Queue<string> sentences; //restrictive list, first in first out

    //for dropping objects in dragdrop script
    public bool isDialogBoxUp = false;
    
    void Start()
    {
        GameManager = FindObjectOfType<GameManager>();

        sentences = new Queue<string>();

        ToggleDragDrop(false);
    }

    public void StartDialogue(Dialogue dialogue)
    {

        isDialogBoxUp = true;

        //activate dialogue box, then swipe it in
        Sequence mySequence = DOTween.Sequence();
        mySequence.Insert(0f, DialogueBox.GetComponent<RectTransform>().DOScaleX(1f, 0.75f).SetEase(Ease.InOutSine));
        mySequence.Insert(0f, BehindDialogueBox.GetComponent<CanvasGroup>().DOFade(0.5f, 0.5f));
        mySequence.AppendCallback(()=> ToggleDragDrop(false));
        mySequence.Play();

        //deactivate non text stuff

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

        isDialogBoxUp = false;

        Debug.Log("end conversation");

        //reactivate non text stuff in sequence?

        Sequence mySequence = DOTween.Sequence();
        mySequence.Insert(0f, DialogueBox.GetComponent<RectTransform>().DOScaleX(0f, 0.75f).SetEase(Ease.InOutSine));
        mySequence.Insert(0f, BehindDialogueBox.GetComponent<CanvasGroup>().DOFade(1f, 0.5f));
        mySequence.AppendCallback(()=> ToggleDragDrop(true));
        mySequence.AppendCallback(()=> GameManager.StateChanger());
        mySequence.Play();
    }


    public void ToggleDragDrop(bool value)
    {
        for (int i = 0; i < 8; i++)
        {
            Ingredients.transform.GetChild(i).GetComponent<DragDrop>().enabled = value;
        }
    }
}
