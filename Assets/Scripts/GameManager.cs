using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class GameManager : MonoBehaviour
{
    public GameObject startingOverlay;
    public GameObject endingOverlay;

    public List<StoryElement> expositionElements;

    public int GameState;

    public bool ChangeState = false;

    public List<GameObject> IngredientsAdded;

    public List<ShakeCollider> ShakeColliders;

    // Start is called before the first frame update
    void Start()
    {
        GameState = 0;
        TitleFadeOut();

        ShakeColliders.AddRange(FindObjectsOfType<ShakeCollider>());
    }

    // Update is called once per frame
    void Update()
    {
        if (GameState == 1 && ChangeState == false)
        {
            TriggerExposition(0);
            ChangeState = true;
        }

        if (GameState == 2 && ChangeState == true)
        {
            TriggerExposition(1);
            ChangeState = false;
        }
        else if (GameState == 3 && ChangeState == false)
        {
            TriggerExposition(2);
            ChangeState = true;
        }
        else if(GameState == 4 && ChangeState == true)
        {
            TriggerExposition(3);
            ChangeState = false;
        }
        else if (GameState == 5 && ChangeState == false) 
        {
            Debug.Log("AT THIS POINT THE GAME WILL QUIT");
            EndingFades();
        }

    }

    private void TitleFadeOut()
    {
        Sequence mySequence = DOTween.Sequence();
        mySequence.AppendInterval(3f);
        mySequence.Append(startingOverlay.GetComponent<CanvasGroup>().DOFade(0f, 1f));
        mySequence.AppendCallback(()=> GameState++);
        mySequence.AppendCallback(()=> startingOverlay.SetActive(false));
    }

    private void EndingFades() 
    {
        Sequence mySequence = DOTween.Sequence();
        mySequence.AppendCallback(()=> endingOverlay.SetActive(true));
        mySequence.Append(endingOverlay.GetComponent<CanvasGroup>().DOFade(1f, 1f));
        mySequence.AppendInterval(3f);
        mySequence.Append(endingOverlay.transform.GetChild(0).GetComponent<CanvasGroup>().DOFade(0f, 1f));
        mySequence.AppendInterval(3f);
        mySequence.AppendCallback(()=> Application.Quit());
        
    }

    public void TriggerExposition(int exposition)
    {
        expositionElements[exposition].TriggerDialogue();
    }

    public void StateChanger()
    {
        if (IngredientsAdded.Count == 8)
        {
            GameState++;
            IngredientsAdded.Clear();
            
            foreach(ShakeCollider sc in ShakeColliders)
            {
                sc.IngredientAmountCounter = 0;
            }

        }
        else if (GameState == 4)
        {
            GameState++;
        }

    }

}
