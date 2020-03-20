using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Bomb : MonoBehaviour
{
    public bool bombArmed = true;

    [SerializeField]
    GameObject diffuseBomb;
    [SerializeField]
    GameObject diffusing;

    private void Update()
    {
        if (diffusing.active)
            StartCoroutine(DiffuseTime());
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && bombArmed && !diffusing.active)
            diffuseBomb.SetActive(true);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
            diffuseBomb.SetActive(false);
    }

    IEnumerator DiffuseTime()
    {
        yield return new WaitForSeconds(2f);
        diffusing.SetActive(false);
        bombArmed = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
