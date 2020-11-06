using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropParticles : MonoBehaviour
{

    public GameObject pSystem;

    private float pTime;
    
    public void InstantiateParticleSystem()
    {
        GameObject instance = Object.Instantiate(pSystem, 
            new Vector2(this.gameObject.transform.position.x, this.gameObject.transform.position.y), Quaternion.identity);
    }

    
    // private ParticleSystem pSystem;

    // private float pTime;

    // private void Awake() 
    // {
    //     pSystem = GetComponentInChildren<ParticleSystem>();
    // }

    // public void DropParticlesFromObject ()
    // {
    //     pSystem.Play();
    //     pTime = Time.time;

    //     if (Time.time - pTime > 0.2f)
    //     {
    //         pSystem.Clear();
    //     }

    // }
}
