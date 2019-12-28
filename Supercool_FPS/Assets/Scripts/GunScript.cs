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
        transform.parent = null;     //CLEARS PARENT OF THE GUN FROM ENEMY OBJECT
        Throw(false);                //ENABLES COLLIDER AND RIGIDODY ON GUN WHEN RELEASED BY ENEMY
    }

    void Throw(bool state)          
    {
        rb.isKinematic = state;
        col.enabled = !state;
    }
}
