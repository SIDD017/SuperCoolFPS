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

    // Start is called before the first frame update
    void Start()
    {
       
    }

    private void Awake()
    {
        b = GameObject.FindGameObjectWithTag("Player");
        if (b != null)
        {
            Debug.Log("FFFFFFFUCK");
            bullet = b.GetComponent<Bullet>();
        }
        rb = GetComponent<Rigidbody>();

        expelDir = new Vector3(Random.Range(50f, 100f), Random.Range(50f, 100f), 10f);
        rb.AddForce(bullet.muzzShellPos.transform.position + expelDir);
        t = Time.time;
    }
    // Update is called once per frame
    void Update()
    {
        if ((Time.time - t) >= 5)
            Destroy(this.gameObject);
    }
}
