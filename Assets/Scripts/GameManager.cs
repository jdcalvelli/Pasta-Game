using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public List<StoryElement> expositionElements;

    public int GameState;

    public bool ChangeState = false;

    public List<GameObject> IngredientsAdded;

    // Start is called before the first frame update
    void Start()
    {
        GameState = 1;
        Invoke("StartExposition", 0.5f); //like a coroutine lmao
    }

    // Update is called once per frame
    void Update()
    {

        if (GameState == 2 && ChangeState == false)
        {
            TriggerExposition(1);
            ChangeState = true;
        }
        else if (GameState == 3 && ChangeState == true)
        {
            TriggerExposition(2);
            ChangeState = false;
        }
        else if(GameState == 4 && ChangeState == false)
        {
            TriggerExposition(3);
            ChangeState = true;
        }

    }

    private void StartExposition()
    {
        TriggerExposition(0);
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
        }

    }

}
