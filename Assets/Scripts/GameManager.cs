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

    public Camera MainCamera;

    // Start is called before the first frame update
    void Start()
    {
        GameState = 0;
        TitleFadeOut();

        ShakeColliders.AddRange(FindObjectsOfType<ShakeCollider>());

        MainCamera = FindObjectOfType<Camera>();
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

            ChangeCameraBGColor(174, 198, 207);
        }
        else if (GameState == 3 && ChangeState == false)
        {
            TriggerExposition(2);
            ChangeState = true;

            ChangeCameraBGColor(174, 207, 183);
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

    private void ChangeCameraBGColor(byte r, byte g, byte b)
    {
        MainCamera.DOColor(new Color32(r, g, b, 255), 3f);
    }

    private void TitleFadeOut()
    {
        Sequence mySequence = DOTween.Sequence();
        mySequence.AppendInterval(4f);
        mySequence.Append(startingOverlay.GetComponent<CanvasGroup>().DOFade(0f, 2f));
        mySequence.AppendCallback(()=> GameState++);
        mySequence.AppendCallback(()=> startingOverlay.SetActive(false));
    }

    private void EndingFades() 
    {
        Sequence mySequence = DOTween.Sequence();
        mySequence.AppendCallback(()=> endingOverlay.SetActive(true));
        mySequence.Append(endingOverlay.GetComponent<CanvasGroup>().DOFade(1f, 3f));
        mySequence.AppendInterval(4f);
        mySequence.Append(endingOverlay.transform.GetChild(0).GetComponent<CanvasGroup>().DOFade(0f, 3f));
        mySequence.AppendInterval(4f);
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
