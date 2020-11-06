using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shake : MonoBehaviour
{
    private bool shake;
    Vector2 oldMouseAxis;

    private int shakeCounter;
    private float shakeTime;

    // Vector2 oldObjectPosition;
    // Vector2 oldObjectDeltaPos;

    private void Awake() 
    {
        shakeCounter = 0;
        shakeTime = Time.time;    
    }

    public void MouseToShake()
    {
         // Vector2 objectPosition = new Vector2(rectTransform.position.x, rectTransform.position.y);
        // Vector2 objectDeltaPos = new Vector2(objectPosition.x - oldObjectPosition.x, objectPosition.y - oldObjectPosition.y);
        
        // this.shake = Mathf.Sign(objectDeltaPos.y) != Mathf.Sign(this.oldObjectDeltaPos.y) 
        //     && Mathf.Abs(Mathf.Abs(objectDeltaPos.y) - Mathf.Abs(oldObjectDeltaPos.y)) > 1.5f;
        // this.oldObjectPosition = objectPosition;
        // this.oldObjectDeltaPos = objectDeltaPos;

        Vector2 mouseAxis = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
        //Debug.Log(mouseAxis);

        this.shake = Mathf.Sign(mouseAxis.y) != Mathf.Sign(this.oldMouseAxis.y) && 
            Mathf.Abs(Mathf.Abs(mouseAxis.y) - Mathf.Abs(oldMouseAxis.y)) > 0.05f;
        this.oldMouseAxis = mouseAxis;

        if (this.shake)
        {
            shakeCounter++;
            shakeTime = Time.time;
            if (shakeCounter > 3)
            {
                Debug.Log("Shake");
                GetComponent<DropParticles>().InstantiateParticleSystem();
            }
        }
        else if (Time.time - shakeTime > 1f)
        {
            shakeCounter = 0;
        }
    }
       
}
