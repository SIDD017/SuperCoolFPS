using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorAnim : MonoBehaviour
{
    public GameObject door;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("door open");
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("door open");
            door.GetComponent<Animator>().SetBool("doorOpen", true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("door closed");
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("door closed");
            door.GetComponent<Animator>().SetBool("doorOpen", false);
        }
    }
}
