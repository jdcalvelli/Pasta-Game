using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeCollider : MonoBehaviour
{

public Shake shake;

private void Awake() 
{
    shake = GetComponent<Shake>();
}

private void OnTriggerStay2D(Collider2D other) 
{
    Debug.Log("triggering!");
    if (shake.RegisterShake)
    {
        Debug.Log("trigger register shaking");
    }
}

}
