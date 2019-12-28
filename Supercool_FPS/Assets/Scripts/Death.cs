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
        manager.EventTrigger();                                                      //OVERRIDE TIMESCALE VALUE WHEN ENEMY DIES 
        this.gameObject.GetComponent<Animator>().enabled = false;                    //SETTING ANIMATOR COMPONENT ON THE ENEMY HIT TO FALSE
        Rigid(false);                                                                //BOTH RIGID AND COLLIDOR FUNCTIONS ARE USED TO CONTROL
        Collidor(true);                                                              //ENEMY RAGDOLLS
        if(this.gameObject.GetComponentInChildren<GunScript>() != null)              
        this.gameObject.GetComponentInChildren<GunScript>().Release();               //IF ENEMY HAS A GUN THEN IT SHOULD BE RELEASED WHEN HE DIES
        //GetComponent<EnableShatter>().Destruct();
       // manager.Slowdowntime();
    }

    void Rigid(bool state)                                                           //FUNCTION TO SET STATE OF RAGDOLL RIGIDBODY
    {
        Rigidbody[] rb = GetComponentsInChildren<Rigidbody>();
        foreach (Rigidbody r in rb)
        {
            r.isKinematic = state;
            r.interpolation = RigidbodyInterpolation.Interpolate;
        }
    }

    void Collidor(bool state)                                                       //FUNCTION TO SET THE STATE OG RAGDOLL COLLIDER
    {
        Collider[] cd = GetComponentsInChildren<Collider>();
        foreach (Collider c in cd)
        {
            c.enabled = state;
        }
    }
}
