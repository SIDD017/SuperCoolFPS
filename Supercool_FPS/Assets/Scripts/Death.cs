using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{
    TimeManager manager;

    float t;
    // Start is called before the first frame update
    void Start()
    {
        manager = FindObjectOfType<TimeManager>();
        t = 0;
        Rigid(true);
        Collidor(true);
    }

    // Update is called once per frame
    void Update()
    {
       /* if (Time.timeScale < 1f)
            Time.timeScale += 0.001f;*/
    }

    public void die()
    {
        this.gameObject.GetComponent<Animator>().enabled = false;
        Rigid(false);
        Collidor(true);
        if(this.gameObject.GetComponentInChildren<GunScript>() != null)
        this.gameObject.GetComponentInChildren<GunScript>().Release();
       // manager.Slowdowntime();
    }

    void Rigid(bool state)
    {
        Rigidbody[] rb = GetComponentsInChildren<Rigidbody>();
        foreach (Rigidbody r in rb)
        {
            r.isKinematic = state;
            r.interpolation = RigidbodyInterpolation.Interpolate;
        }
    }

    void Collidor(bool state)
    {
        Collider[] cd = GetComponentsInChildren<Collider>();
        foreach (Collider c in cd)
        {
            c.enabled = state;
        }
    }
}
