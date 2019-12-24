using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableShatter : MonoBehaviour
{
    public GameObject rigged;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Destruct()
    {
        Destroy(this.gameObject);
        GameObject rig = Instantiate(rigged, this.transform.position, this.transform.rotation);
        rig.GetComponent<Explode>().Shatter();
    }
}
