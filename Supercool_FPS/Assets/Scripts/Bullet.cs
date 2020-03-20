using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Bullet : MonoBehaviour
{
    public GameObject Uimanager;
    AudioSource shotFired;
    public int cureentBullets;

    //Death death;                                           
    TimeManager manager;

    public Vector3 bulletpath;
    public float speed;

    public float range;

    float t;

    public GameObject bullet;
    public GameObject shell;
    public Camera fps;
    public GameObject muzzShellPos;
    public GameObject muzzPos;
    public GameObject muzzleFlash;
    public GameObject muzzleSmoke;
    public GameObject bulletShell;
    Vector3 shootDir = new Vector3(0f,0f,-1f);

    public RaycastHit rayhit;
    int ignoreEnemyDetectLayer = 1 << 9;

    void Start()
    {
        shotFired = Uimanager.GetComponent<AudioSource>();
        manager = FindObjectOfType<TimeManager>();
        ignoreEnemyDetectLayer = ~ignoreEnemyDetectLayer;
       // death = GameObject.FindGameObjectWithTag("Player").GetComponent<Death>();
        t = 0;
        cureentBullets = 7;
    }

    void Update()
    {
        if (CrossPlatformInputManager.GetButtonDown("Fire1"))                         
        {
            
            Vector3 bulletpath;
            Vector3 camcenter = fps.ScreenToWorldPoint(new Vector3(Screen.width / 2, Screen.height / 2, 0f));   //TO GET CENTER POSITION OF CAMERA IN WORLDSPACE

            RaycastHit rayhit;                                                                                  // RAYCAST TO STORE INFO OF OBJECT THE PLAYER IS FACING
            if (Physics.Raycast(camcenter, fps.transform.forward, out rayhit, range, ignoreEnemyDetectLayer))
            {
                
                bulletpath = (rayhit.point - muzzPos.transform.position);                                      //CALCULATES THE VECTOR FROM GUN MUZZLE TO THE OBJECT THE RAYCAST HITS
            }
            else
            {
                bulletpath = ((camcenter+(fps.transform.forward.normalized*range)) - muzzPos.transform.position);   //IF NO OBJECT FOUND BY RAYCAST THEN BULLETPATH CALULATED FOR SPECIFIED RANGE
            }
                                                                       //SETS THE MUZZLEFLASH PARTICLE SYSTEM ACTIVE
            

            t = Time.time;
            if (cureentBullets > 0)
            {
                shotFired.Play();
                muzzleFlash.SetActive(true);
                Instantiate(bulletShell, muzzShellPos.transform.position, muzzShellPos.transform.rotation);   //INSTANTIATES BULLETSHELL
                GameObject bt = Instantiate(bullet, muzzPos.transform.position, Quaternion.LookRotation(bulletpath));    //INSTANTIATES BULLET
                bt.GetComponent<Rigidbody>().velocity = bulletpath.normalized * speed;                        //SETTING BULLET VELOCITY
                bt.GetComponent<Rigidbody>().isKinematic = false;
                cureentBullets = cureentBullets - 1;
                manager.EventTrigger();                                                                       //OVERRIDING TIMESCALE FOR SHOOTING EVENT
            }
            else
            {
                Debug.Log("You're out of bullets");
            }
        }
        
        

        if ((Time.time - t) >= 0.06)                                                 //DISABLE MUZZLEFLASH AFTER 0.06 SECONDS
        {
         // muzzleSmoke.SetActive(true);
            muzzleFlash.SetActive(false);
        }
         
      /* if ((Time.time - t) >= 0.3)
          muzzleSmoke.SetActive(false);*/
    }

    /*void punch(Vector3 impulseDirection, Vector3 impulsePoint, Rigidbody rb)
    {
        Vector3 punchForce = impulseDirection.normalized * 10f;
        rb.AddForceAtPosition(punchForce, impulsePoint);
    }*/

}
