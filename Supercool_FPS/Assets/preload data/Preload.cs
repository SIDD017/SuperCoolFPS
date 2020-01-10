using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Preload : MonoBehaviour
{
    CanvasGroup fade;
    float loadTime;
    float minLogoTime = 3f;

    private void Start()
    {
        fade = FindObjectOfType<CanvasGroup>();
        fade.alpha = 1f;

        if (Time.time < minLogoTime)
            loadTime = minLogoTime;
        else
            loadTime = Time.time;
    }
}
