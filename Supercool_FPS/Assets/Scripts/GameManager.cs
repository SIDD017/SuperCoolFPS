using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    string currentScene;
    public static GameManager _instance;
    public static GameManager instance
    {
        get
        {
            return _instance;
        }
    }

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        if (_instance != null && _instance != this)
            Destroy(this.gameObject);
        else
            _instance = this;
    }

    public enum StateType
    {
        PRELOAD=0,
        FIRSTLEVEL = 90,
        SECONDLEVEL = 55,
        PAUSEMENU,
        RESUMESTATE,
        GAMEOVER,
        FIRSTLEVELSUCCESS,
        SECONDLEVELSUCCESS

    }

    public StateType currentLevel;
    public StateType currentState;

    public void ChangeState(StateType state)
    {
        currentState = state;
        Debug.Log("State changed to : " + currentState);
    }

    public void ChangeLevel(StateType state)
    {
        currentLevel = state;
        Debug.Log("Current level is : " + currentLevel);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void VisitDevsocLink()
    {
        Application.OpenURL("https://devsoc.club/");
    }
}

