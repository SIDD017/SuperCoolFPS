using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    Text countdown;

    [SerializeField]
    Text bulletCount;

    [SerializeField]
    TimeManager manager;
    string currentScene;
    [SerializeField]
    GameObject pauseScreen;
    [SerializeField]
    GameObject gameScreen;
    [SerializeField]
    GameObject gameOverScreen;
    Bullet bull;

    private void Awake()
    {
        bull = FindObjectOfType<Bullet>();
        manager = FindObjectOfType<TimeManager>();
        // pauseScreen = 
        //  currentScene = SceneManager.GetActiveScene().name;
    }

    private void FixedUpdate()
    {
        BulletInventory();
        Countdown(); 
        
    }

    void BulletInventory()
    {
        int temp = bull.cureentBullets;
        bulletCount.text = temp.ToString();
        if (temp == 0)
            bulletCount.color = Color.red;
    }

    void Countdown()
    {
        int timeLeft = (int)((int)GameManager.StateType.FIRSTLEVEL - Time.timeSinceLevelLoad);
        if (timeLeft >= 0)
        {
            countdown.text = "0:" + timeLeft.ToString();
            if (timeLeft > 5)
                countdown.color = Color.white;
            else if (timeLeft < 5)
                countdown.color = Color.red;
        }
        else if (timeLeft < 0)
            GameOverScreen();
    }

    public void LoadPauseScreen()
    {
        GameManager.instance.ChangeState(GameManager.StateType.PAUSEMENU);
        gameScreen.SetActive(false);
        manager.enabled = false;
        Time.timeScale = 0f;
        pauseScreen.SetActive(true);
    }

    public void ResumeGame()
    {
        GameManager.instance.ChangeState(GameManager.StateType.RESUMESTATE);
        gameScreen.SetActive(true);
        pauseScreen.SetActive(false);
        manager.enabled = true;
    }

    public void GameOverScreen()
    {
        GameManager.instance.ChangeState(GameManager.StateType.GAMEOVER);
        gameScreen.SetActive(false);
        gameOverScreen.SetActive(true);
    }

    public void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex, LoadSceneMode.Single);
    }
}
