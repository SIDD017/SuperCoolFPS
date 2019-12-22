using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public float targetScale;
    public float restoreRate;
    float fixedDelta;
    float delta;
    float lerpSpeed;
    float t = 0.2f;

    // Start is called before the first frame update
    void Start()
    {
        delta = Time.deltaTime;
        fixedDelta = Time.fixedDeltaTime;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");
        if (Input.anyKey)
        {
            targetScale = 1f;
            lerpSpeed = 200;
           
        }
        else if (mouseX != 0f || mouseY != 0f)
        {
            targetScale = 0.5f;
            lerpSpeed = 200;
           
        }

        else
        {
            targetScale = 0;
            lerpSpeed = 10;
            
        }
        t = Mathf.Lerp(t, targetScale, Time.deltaTime * lerpSpeed);
        Slowdowntime(t);
    }

    public void Slowdowntime(float scale)
    {
        Time.timeScale = scale;
        Time.fixedDeltaTime = fixedDelta * scale;
    }
}
