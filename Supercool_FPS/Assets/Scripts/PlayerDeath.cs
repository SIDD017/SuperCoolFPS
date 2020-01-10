using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class PlayerDeath : MonoBehaviour
{
    public PostProcessProfile gameMenu;
    ColorGrading co;

    float coValue;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void FixedUpdate()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag("Player"))
        {
            FindObjectOfType<GameOver>().playerDead = true;
            FindObjectOfType<TimeManager>().playerdeath = true;
            collision.gameObject.GetComponent<CharacterController>().enabled = false;     //DISABLE CHARACTER CONTROLLER
            collision.gameObject.GetComponent<AudioSource>().enabled = false;             //DISABLE FOOTSTEPS AUDIO SOURCE
            collision.gameObject.GetComponent<Bullet>().enabled = false;                  //DISABLE BULLET SCRIPT
            collision.gameObject.GetComponentInChildren<Camera>().transform.DetachChildren();   //ALL CHILDREN OF THE CHARACTER CONTROLLER ARE SEPERATED
            Debug.Log("GameOver");
            Destroy(this.gameObject);
        }
        else if (!collision.gameObject.CompareTag("Enemy") && !collision.gameObject.CompareTag("MainEnemy") && !collision.gameObject.CompareTag("Gun"))
            Destroy(this.gameObject);
    }

}
