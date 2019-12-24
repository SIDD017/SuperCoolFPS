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
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Instantiate(deathParticle,transform.position,transform.rotation);
            collision.gameObject.GetComponentInParent<Death>().die();
            Debug.Log("LeftLeg");
            collision.gameObject.GetComponent<Rigidbody>().AddForceAtPosition(rb.velocity.normalized * 60f, collision.transform.position, ForceMode.Impulse);
            Destroy(this.gameObject);
        }

        Destroy(this.gameObject);
    }

}
