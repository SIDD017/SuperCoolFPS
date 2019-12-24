using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Death death;

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
        ignoreEnemyDetectLayer = ~ignoreEnemyDetectLayer;
        death = GameObject.FindGameObjectWithTag("Player").GetComponent<Death>();
        t = 0;
    }



    void Update()
    {
        
        if (Input.GetButtonDown("Fire1"))
        {
            Vector3 bulletpath;
            Vector3 camcenter = fps.ScreenToWorldPoint(new Vector3(Screen.width / 2, Screen.height / 2, 0f));

            RaycastHit rayhit;
            if (Physics.Raycast(camcenter, fps.transform.forward, out rayhit, range, ignoreEnemyDetectLayer))
            {
                bulletpath = (rayhit.point - muzzPos.transform.position);
                Debug.Log("path =" + bulletpath);
            }
            else
            {
                bulletpath = ((camcenter+(fps.transform.forward.normalized*range)) - muzzPos.transform.position);
                Debug.Log("No path =" + bulletpath);
            }
            muzzleFlash.SetActive(true);

            

            t = Time.time;
            Instantiate(bulletShell, muzzShellPos.transform.position, muzzShellPos.transform.rotation);
            GameObject bt=Instantiate(bullet, muzzPos.transform.position, muzzPos.transform.rotation);
            bt.GetComponent<Rigidbody>().velocity = bulletpath.normalized * speed;
            bt.GetComponent<Rigidbody>().isKinematic = false;
        }
        
        

        if ((Time.time - t) >= 0.025)
        {
          muzzleSmoke.SetActive(true);
            muzzleFlash.SetActive(false);
        }
         
       if ((Time.time - t) >= 0.3)
          muzzleSmoke.SetActive(false);
    }

    

}
