using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunScript : MonoBehaviour
{
    Rigidbody rb;
    Collider col;

    // Start is called before the first frame update
    void Start()
    {
        col = GetComponent<Collider>();
        rb = GetComponent<Rigidbody>();
        Throw(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Release()
    {
        transform.parent = null;
        Throw(false);
    }

    void Throw(bool state)
    {
        rb.isKinematic = state;
        col.enabled = !state;
    }
}
