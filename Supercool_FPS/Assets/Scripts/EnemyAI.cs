using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    GameObject player;
    float fireRate=0.2f;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<Animator>().enabled == true)
            //this.gameObject.transform.forward = (player.transform.position - this.gameObject.transform.position);
            this.gameObject.transform.LookAt(player.transform);
    }
}
