using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    TimeManager manager;
    public GameObject uimanager;
    float ti;

    public GameObject deathParticleEffect;
    public GameObject muzzlePos;
    public GameObject bullet;
    GameObject player;
    float fireRate=0.2f;
    Vector3 playerPos;
    Vector3 passPos;
    float speed = 10f;
    public GameObject muzzFlash;

    Animator anim;
    float t;

    void Start()
    {
        anim = this.GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player Target");

        manager = FindObjectOfType<TimeManager>();
        ti = 0;
        Rigid(true);
        Collidor(true);
    }

    void Update()
    {
        if (GetComponent<Animator>().enabled == true)
        {
            playerPos = (player.transform.position - this.gameObject.transform.position);
           
            FacePlayer(playerPos);
        }

        if(muzzFlash.active && (Time.time - t)>=0.01f)
        {
            muzzFlash.SetActive(false);
        }

    }

    void FacePlayer(Vector3 pos)
    {
        passPos = new Vector3(pos.x, 0f, pos.z).normalized;
        this.transform.rotation = Quaternion.LookRotation(passPos, transform.up);
    }

    void Fire()
    {
        uimanager.GetComponent<AudioSource>().Play();
        Vector3 targetPlayer = (player.transform.position - muzzlePos.transform.position);
        muzzFlash.SetActive(true);
        t = Time.time;
        GameObject b = Instantiate(bullet, muzzlePos.transform.position, muzzlePos.transform.rotation);
        b.GetComponent<Rigidbody>().velocity = targetPlayer.normalized * speed;
        b.GetComponent<Rigidbody>().isKinematic = false;
    }

    void Shoot(bool state)
    {
        
        anim.SetBool("Shoot",state);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
            Shoot(true);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
            Shoot(false);
    }

    public void die()
    {
        manager.EventTrigger();                                                      //OVERRIDE TIMESCALE VALUE WHEN ENEMY DIES 
        this.gameObject.GetComponent<Animator>().enabled = false;                    //SETTING ANIMATOR COMPONENT ON THE ENEMY HIT TO FALSE
        Rigid(false);                                                                //BOTH RIGID AND COLLIDOR FUNCTIONS ARE USED TO CONTROL
        Collidor(true);                                                              //ENEMY RAGDOLLS
        if (this.gameObject.GetComponentInChildren<GunScript>() != null)
            this.gameObject.GetComponentInChildren<GunScript>().Release();               //IF ENEMY HAS A GUN THEN IT SHOULD BE RELEASED WHEN HE DIES
        FindObjectOfType<Bullet>().cureentBullets += 2;                                                                                 //GetComponent<EnableShatter>().Destruct();
        StartCoroutine(DeathDestroyer());                                                                                 // manager.Slowdowntime();
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

    IEnumerator DeathDestroyer()
    {
        yield return new WaitForSeconds(2f);
        Instantiate(deathParticleEffect, transform.position, transform.rotation);
        Destroy(this.gameObject);
    }
}
