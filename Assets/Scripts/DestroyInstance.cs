using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyInstance : MonoBehaviour
{
    private void Start() {
        StartCoroutine(KillInstance());        
    }

    IEnumerator KillInstance()
    {
        yield return new WaitForSeconds(1f);
        GetComponent<ParticleSystem>().Clear();
        Destroy(this.gameObject);
    }
}
