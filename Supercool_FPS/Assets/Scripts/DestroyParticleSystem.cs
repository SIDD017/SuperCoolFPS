using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyParticleSystem : MonoBehaviour
{
    void Update()
    {
        if (this.gameObject.active)
            StartCoroutine(DeathTimeBuffer());
    }

    IEnumerator DeathTimeBuffer()
    {
        yield return new WaitForSeconds(1f);
        Destroy(this.gameObject);
    }
}
