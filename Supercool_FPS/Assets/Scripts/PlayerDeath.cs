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
        
        if(collision.gameObject.CompareTag("Player"))
        {
            FindObjectOfType<GameOver>().playerDead = true;
            FindObjectOfType<TimeManager>().playerdeath = true;
            collision.gameObject.GetComponent<CharacterController>().enabled = false;
            collision.gameObject.GetComponent<AudioSource>().enabled = false;
            collision.gameObject.GetComponent<Bullet>().enabled = false;
            collision.gameObject.GetComponentInChildren<Camera>().transform.DetachChildren();
            Debug.Log("GameOver");
            Destroy(this.gameObject);
        }
    }

}
