using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TimeManager : MonoBehaviour
{
    public float targetScale;
    public float restoreRate;
    float fixedDelta;
    float delta;
    float lerpSpeed;
    float t = 0.2f;
    bool eventtime  = false;
    public bool playerdeath = false;

    void Start()
    {
        delta = Time.deltaTime;
        fixedDelta = Time.fixedDeltaTime;
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");
            if (Input.anyKey && !playerdeath)                     //ANY KEY PRESSED AND IS THE PLAYER STILL ALIVE
            {
                targetScale = 1f;
                lerpSpeed = 200;
            }

            else if (playerdeath)                                //EXECUTED IF PLAYER DIES
            {
                targetScale = 0.05f;
                lerpSpeed = 200;
            }

            else if (eventtime)                                   //EXECUTED ON EVENTS OF PLAYER SHOOTING OR ENEMY DEATH
            {
                targetScale = 0.5f;
                lerpSpeed = 200;
            }

            /*else if ((mouseX != 0f || mouseY != 0f) && !playerdeath)   //EXECUTED IF PLYER MOVES THE CAMERA USING MOUSE
            {
                targetScale = 0.2f;
                lerpSpeed = 200;
            }*/

            else                                                 //TIMESCALE LERPS TO ZERO IF NO ACTIVITY
            {
                targetScale = 0;
                lerpSpeed = 10;
            }
            t = Mathf.Lerp(t, targetScale, Time.deltaTime * lerpSpeed);   //LINEAR INTERPOLATION BETWEEN TIMESCALE VALUES
            Slowdowntime(t);
        
    }

    public void EventTrigger()               
    {
        StartCoroutine(EventTime());
    }

    IEnumerator EventTime()                 /*CHANGING TIMESCALE VALUE FOR EVENTS LIKE SHOOTING AND ENEMYDEATH 
                                              BY USING BOOLEAN FOR 0.16 SECONDS*/
    {
        eventtime = true;
        yield return new WaitForSeconds(0.16f);
        eventtime = false;
    }

    public void Slowdowntime(float scale)   //CHANGING TIMESCALE AND FIXEDELTATIME TO ACHIEVE TIME MANIPULATION EFFECT
    {
        Time.timeScale = scale;
        Time.fixedDeltaTime = fixedDelta * scale;
    }

}
