using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
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

    // Start is called before the first frame update
    void Start()
    {
        anim = this.GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
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

    
}
