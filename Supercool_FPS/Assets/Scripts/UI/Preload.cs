using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Preload : MonoBehaviour
{
    public Image logo;
    public Text loading;
    public GameObject startScreen;
    public Color minAlpha;
    public Color maxAlpha;
    bool loadLogo;
    bool startFade = false;
    float fadeRate;

    private void Start()
    {
        fadeRate = 0f;
        loading.enabled = false;
        startScreen.SetActive(false);
        logo.enabled = true;
        logo.color = minAlpha;
        loadLogo = true;
    }

    private void Update()
    {
       if(loadLogo)
        {
            StartCoroutine(FadeLogo());
        }

    }

   IEnumerator FadeLogo()
    {

        if (!startFade)
        {
            fadeRate += Time.deltaTime;
            logo.color = Color.Lerp(logo.color, maxAlpha, fadeRate / 1f);
        }
        if (logo.color == maxAlpha)
        { yield return new WaitForSeconds(1f);
            startFade = true;
            fadeRate = 0f;
        }
        if (startFade)
        {
            fadeRate += Time.deltaTime;
            logo.color = Color.Lerp(logo.color, minAlpha, fadeRate / 0.5f);
        }
        if (logo.color == minAlpha)
        {
            loadLogo = false;
            logo.enabled = false;
            startScreen.SetActive(true);
        }
    }

    void EnableLoadingScreen()
    {
        loading.enabled = true;
    }

    public void LoadNextScene()
    {
        startScreen.SetActive(false);
        EnableLoadingScreen();
        GameManager.instance.ChangeLevel(GameManager.StateType.FIRSTLEVEL);
        SceneManager.LoadSceneAsync(1);
    }
}
