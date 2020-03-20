using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawned : MonoBehaviour
{
    Rigidbody rb;
    public GameObject deathParticle;

    public float speed;
    Camera cam;
    public int damage;
    public float hitforce;

    Bullet bull;
    TimeManager time;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        bull = GameObject.FindGameObjectWithTag("Player").GetComponent<Bullet>();
        time = FindObjectOfType<TimeManager>();
    }


    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))                      //IF BULLET HITS ENEMY
        {
            Instantiate(deathParticle,transform.position,transform.rotation);         //INSTANTIATES ENEMYDEATH PARTICLE SYSTEM
            collision.gameObject.GetComponentInParent<EnemyAI>().die();                 //CALLS DIE FUNCTION IN DEATH SCRIPT ATTACHED TO THE ENEMY OBJECT
            //Debug.Log("LeftLeg");
            collision.gameObject.GetComponent<Rigidbody>().AddForceAtPosition(rb.velocity.normalized * 60f, collision.transform.position, ForceMode.Impulse);  /*ADDS AN IMPULSE TO THE ENEMY RAGDOLL 
                                                                                                                                                                 AT THE POINT THE BULLET HITS THE ENEMY*/
            Destroy(this.gameObject);                       //DESTROYS BULLET
        }

        Destroy(this.gameObject);                           //DESTROYS BULLET IF IT DID NOT COLLIDE WITH ENEMY BUT WITH ANY OTHER COLLIDER IN THE SCENE
    }

}
