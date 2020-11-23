using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DropParticles : MonoBehaviour
{

    public List<GameObject> pSystems = new List<GameObject>();
    
    private float pTime;
    
    public void InstantiateParticleSystem(int i, float x, float y)
    {
        GameObject instance = Object.Instantiate(pSystems[i], 
            new Vector2(x, y), Quaternion.identity);
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
