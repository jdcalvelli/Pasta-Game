using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public List<StoryElement> expositionElements;

    public int GameState;

    public bool ChangeState = false;

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
    }

    private void StartExposition()
    {
        TriggerExposition(0);
    }

    public void TriggerExposition(int exposition)
    {
        expositionElements[exposition].TriggerDialogue();
    }
}
