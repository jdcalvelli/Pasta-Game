using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shake : MonoBehaviour
{

    public DropParticles ParticleSpawner;
    public int PSystemToSpawn;

    public bool IsShaking;

    public bool RegisterShake;
    Vector2 oldMouseAxis;

    private int shakeCounter;
    private float shakeTime;

    // Vector2 oldObjectPosition;
    // Vector2 oldObjectDeltaPos;

    private void Awake() 
    {
        shakeCounter = 0;
        shakeTime = Time.time;    

        ParticleSpawner = FindObjectOfType<DropParticles>();

        switch (this.gameObject.name)
        {
            case "Wine":
                this.PSystemToSpawn = 0;
            break;
            case "Chicken Broth":
                this.PSystemToSpawn = 1;
            break;
            case "Pork":
                this.PSystemToSpawn = 2;
            break;
            case "Pancetta":
                this.PSystemToSpawn = 3;
            break;
            case "Carrot":
                this.PSystemToSpawn = 4;
            break;
            case "Herbs":
                this.PSystemToSpawn = 5;
            break;
            case "Onion":
                this.PSystemToSpawn = 6;
            break;
            case "Celery":
                this.PSystemToSpawn = 7;
            break;
        }
    
    }

    public void MouseToShake()
    {
         // Vector2 objectPosition = new Vector2(rectTransform.position.x, rectTransform.position.y);
        // Vector2 objectDeltaPos = new Vector2(objectPosition.x - oldObjectPosition.x, objectPosition.y - oldObjectPosition.y);
        
        // this.shake = Mathf.Sign(objectDeltaPos.y) != Mathf.Sign(this.oldObjectDeltaPos.y) 
        //     && Mathf.Abs(Mathf.Abs(objectDeltaPos.y) - Mathf.Abs(oldObjectDeltaPos.y)) > 1.5f;
        // this.oldObjectPosition = objectPosition;
        // this.oldObjectDeltaPos = objectDeltaPos;

        Vector2 mouseAxis = new Vector2(0, Input.GetAxis("Mouse Y"));
        //Debug.Log(mouseAxis);

        this.IsShaking = Mathf.Sign(mouseAxis.y) != Mathf.Sign(this.oldMouseAxis.y) && 
            Mathf.Abs(Mathf.Abs(mouseAxis.y) - Mathf.Abs(oldMouseAxis.y)) > 0.1f;
        this.oldMouseAxis = mouseAxis;

        if (this.IsShaking)
        {
            shakeCounter++;
            shakeTime = Time.time;
            if (shakeCounter > 4)
            {
                Debug.Log("Register Shake");
                RegisterShake = true;
                ParticleSpawner.InstantiateParticleSystem(PSystemToSpawn, 
                    this.gameObject.transform.position.x, this.gameObject.transform.position.y);
            }
        }
        else if (Time.time - shakeTime > 2f)
        {
            shakeCounter = 0;
            RegisterShake = false;
        }
        else 
        {
            RegisterShake = false;
        }
    }
       
}
