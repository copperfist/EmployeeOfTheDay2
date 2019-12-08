using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialScreens : MonoBehaviour
{

    public GameObject tutorialScreen1;
    public GameObject tutorialScreen2;
    public static bool GameIsPaused;

    private void Awake()
    {
       GameIsPaused = true;
    }

    public void Update()
    {
        if (GameIsPaused == true)
        {
            Time.timeScale = 0f;
            AudioListener.pause = true;
        }
    }

    public void closeScreenOne()
    {
        tutorialScreen1.SetActive(false);
        tutorialScreen2.SetActive(true);
    }

    public void closeScreenTwo()
    {
        tutorialScreen2.SetActive(false);
        Time.timeScale = 1f;
        AudioListener.pause = false;
        GameIsPaused = false;
    }
}
