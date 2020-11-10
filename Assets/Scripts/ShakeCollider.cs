using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeCollider : MonoBehaviour
{

public GameManager GameManager;

public List<StoryElement> storyElements;
public int[] ingredientCounts;

public Shake shake;

public int IngredientAmountCounter;

private void Awake() 
{
    GameManager = FindObjectOfType<GameManager>();

    this.shake = GetComponent<Shake>();
}

private void OnTriggerStay2D(Collider2D other) 
{
    Debug.Log("triggering!");

    if (GameManager.GameState == 1)
    {
        if (this.shake.RegisterShake)
        {
            this.IngredientAmountCounter++;
            Debug.Log("ingredient amount counter " + this.IngredientAmountCounter);
            for (int i = 0; i < this.storyElements.Count; i++)
            {
                if (this.IngredientAmountCounter == this.ingredientCounts[i])
                {
                    this.storyElements[i].TriggerDialogue();
                }
            }
        }
    }

}

}
