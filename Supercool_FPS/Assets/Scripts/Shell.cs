using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shell : MonoBehaviour
{
    Bullet bullet;
    Vector3 expelDir;
    public Rigidbody rb;
    float t;
    GameObject b;

    private void Awake()                                                        //CALLED WHRN BULLET SHELL INSTANTIATED
    {
        b = GameObject.FindGameObjectWithTag("Player");                        //GETTING THE PLAYER OBJECT   
        if (b != null)
        {
            bullet = b.GetComponent<Bullet>();                                 //GETTING THE BULLET SCRIPT TO ACCESS MUZZLESHELL OBJECT(BULLET SHELLS INSTANTIATE AT THE MUZZLESHELL OBJECT POSITION)
        }
        rb = GetComponent<Rigidbody>();

        expelDir = new Vector3(Random.Range(50f, 100f), Random.Range(50f, 100f), 10f);   //INITIAL DIRECTION FOR EXPELLING BULLET SHELL
        rb.AddForce((bullet.muzzShellPos.transform.position + expelDir));           // FORCE WITH WHICH BULLET SHELL IS EXPELLED FORM GUN
        t = Time.time;                                                             //TIME AT WHICH BULLET IS EXPELLED
    }

    void Update()
    {
        if ((Time.time - t) >= 5)
            Destroy(this.gameObject);                                             //DESTROYS BULLET OBJECT WHEN TIME>5SECONDS SINCE INSTANTIATION
    }
}
