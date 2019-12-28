using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Death death;                                           
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
        manager = FindObjectOfType<TimeManager>();
        ignoreEnemyDetectLayer = ~ignoreEnemyDetectLayer;
        death = GameObject.FindGameObjectWithTag("Player").GetComponent<Death>();
        t = 0;
    }



    void Update()
    {
        
        if (Input.GetButtonDown("Fire1"))                         
        {
            Vector3 bulletpath;
            Vector3 camcenter = fps.ScreenToWorldPoint(new Vector3(Screen.width / 2, Screen.height / 2, 0f));   //TO GET CENTER POSITION OF CAMERA IN WORLDSPACE

            RaycastHit rayhit;                                                                                  // RAYCAST TO STORE INFO OF OBJECT THE PLAYER IS FACING
            if (Physics.Raycast(camcenter, fps.transform.forward, out rayhit, range, ignoreEnemyDetectLayer))
            {
                bulletpath = (rayhit.point - muzzPos.transform.position);                                      //CALCULATES THE VECTOR FROM GUN MUZZLE TO THE OBJECT THE RAYCAST HITS
                //Debug.Log("path =" + bulletpath);
            }
            else
            {
                bulletpath = ((camcenter+(fps.transform.forward.normalized*range)) - muzzPos.transform.position);   //IF NO OBJECT FOUND BY RAYCAST THEN BULLETPATH CALULATED FOR SPECIFIED RANGE
                //Debug.Log("No path =" + bulletpath);
            }
            muzzleFlash.SetActive(true);                                                            //SETS THE MUZZLEFLASH PARTICLE SYSTEM ACTIVE
            

            t = Time.time;
            Instantiate(bulletShell, muzzShellPos.transform.position, muzzShellPos.transform.rotation);   //INSTANTIATES BULLETSHELL
            GameObject bt=Instantiate(bullet, muzzPos.transform.position, muzzPos.transform.rotation);    //INSTANTIATES BULLET
            bt.GetComponent<Rigidbody>().velocity = bulletpath.normalized * speed;                        //SETTING BULLET VELOCITY
            bt.GetComponent<Rigidbody>().isKinematic = false;
            manager.EventTrigger();                                                                       //OVERRIDING TIMESCALE FOR SHOOTING EVENT
        }
        
        

        if ((Time.time - t) >= 0.06)                                                 //DISABLE MUZZLEFLASH AFTER 0.06 SECONDS
        {
         // muzzleSmoke.SetActive(true);
            muzzleFlash.SetActive(false);
        }
         
      /* if ((Time.time - t) >= 0.3)
          muzzleSmoke.SetActive(false);*/
    }

    

}
