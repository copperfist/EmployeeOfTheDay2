using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialScreens : MonoBehaviour
{

    public GameObject tutorialScreen1;
    public GameObject tutorialScreen2;

    private void Awake()
    {
        Time.timeScale = 0f;
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
    }
}
