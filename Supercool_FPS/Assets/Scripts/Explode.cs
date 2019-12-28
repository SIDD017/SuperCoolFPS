using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explode : MonoBehaviour
{
    public float minForce;
    public float maxForce;
    public float radius;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Shatter()     //ADDS AN EXPLOSIVE FORCE TO EVERY OBJECT OF THE ENEMY SHATTERED MESH
    {

        foreach (Transform t in transform)
        {
            Rigidbody rb = t.GetComponent<Rigidbody>();

            if (rb != null)
                rb.AddExplosionForce(Random.Range(minForce, maxForce), transform.position, radius); 
        }
    }
}
