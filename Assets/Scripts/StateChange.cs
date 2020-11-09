using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateChange : MonoBehaviour
{

    public GameManager GameManager;

    private void Awake()
    {
        GameManager = FindObjectOfType<GameManager>();
    }

    public void ChangeState()
    {
        GameManager.GameState++;
        if (GameManager.GameState == 2 && GameManager.ChangeState == false);
        {
            GameManager.TriggerExposition(1);
            GameManager.ChangeState = true;
        }
    }
}
