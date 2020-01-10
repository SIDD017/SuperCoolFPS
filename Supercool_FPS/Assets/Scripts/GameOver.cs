using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public PostProcessProfile gameMenu;
    ColorGrading co;
    DepthOfField dp;                                   

    float redValue;                                         
    float coValue;
    float dpValue;
    public bool playerDead;
    public Color normalColorFilter;
    public Color deadColorFilter;
    Color tempColor;

    public GameObject gameOverScreen;
    public Text[] buttons = new Text[4];
    public Color initialTextAlpha;
    public Color finalTextAlpha;
    Color tempTextAlpha;
    public Image crosshair;
    // Start is called before the first frame update
    void Start()
    {
        gameMenu.TryGetSettings<ColorGrading>(out co);     //GET COLORGRADING SETTINGS IN POSTPROCESS PROFILE
        gameMenu.TryGetSettings<DepthOfField>(out dp);     //GET DEPTHOFFIELD SETTINGS IN POSTPROCESS PROFILE
        dp.focusDistance.value = 5.6f;                     //INITIAL DEPTHOFFIELD FOCUS DISTANCE
        co.temperature.value = -10f;                       //INITIAL COLOR TEMPERATURE
        co.saturation.value = 32;                          //INITIAL COLOR SATURATION
        coValue = -32f;
        playerDead = false;
        dpValue = 5.6f;
        tempColor = normalColorFilter;                      //INITIAL COLOR VALUE = NORMAL COLOR VALUE
        co.colorFilter.value = tempColor;                   //SETTING INITIAL COLOR FILTER VALUE
        tempTextAlpha = initialTextAlpha;                   //INITIAL VALUE FOR ALPHA CHANNEL OF TEXT COLOR
       // crosshair.enabled = true;                           //INITIALLY UI ELEMENT CROSSHAIR ENABLED
    } 

    // Update is called once per frame
    void FixedUpdate()
    {
        if (playerDead)                                       
        {
            gameOverScreen.SetActive(true);                  //ENABLES GAMEOVER SCREEN
            crosshair.enabled = false;                       //DISABLES CROSSHAIR UI
            //Debug.Log("works" + Mathf.Lerp(20f, 100f, 0.5f));
            tempColor = Color.Lerp(tempColor, deadColorFilter, Time.deltaTime * 32f);  //GRADUALLY CHANGE COLOR FILTER VALUE
            tempTextAlpha = Color.Lerp(tempTextAlpha, finalTextAlpha, Time.deltaTime * 32f);   //GRADUALLY CHANGE ALPHA OF TEXT COLOR
            coValue = Mathf.Lerp(coValue, 64f, Time.deltaTime * 32f);       //CHANGE COLOR TEMPERATURE VALUE
            dpValue = Mathf.Lerp(dpValue, 0.1f, Time.deltaTime * 32f);      //CHANGE DEPTH OF FIELD VALUE
            DeathMenu(coValue, dpValue, tempColor, tempTextAlpha);          //CALL FUNCTION
        }
    }

    void DeathMenu(float cgvalue, float dfvalue, Color redvalue, Color alpha)
    {

        gameMenu.TryGetSettings<ColorGrading>(out co);
        gameMenu.TryGetSettings<DepthOfField>(out dp);
        dp.focusDistance.value = dfvalue;
        co.temperature.value = cgvalue;
        co.saturation.value = cgvalue;
        co.colorFilter.value = redvalue;

        for (int i = 0; i < 4; i++)
        {
            buttons[i].GetComponent<Text>().color = alpha;                   //CHANGES ALPHA OF TEXT UI IN GAMEOVER SCREEN 
        }

    }
    void PauseMenu()
    {

    }
}