using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public GameObject levelPanel;

    public void StartGame()
    {
        SceneManager.LoadScene("Concept Level 1");
    }

    public void LevelSelect()
    {
        levelPanel.SetActive(true);
    }

    public void ExitLevelSelect()
    {
        levelPanel.SetActive(false);
    }

    public void TutorialSelect()
    {
        SceneManager.LoadScene("TutorialLevel");
    }

    public void OneOneSelect()
    {
        SceneManager.LoadScene("Concept Level 1");
    }

    public void OneTwoSelect()
    {
        SceneManager.LoadScene("Level 1-2");
    }

    public void OneThreeSelect()
    {
        SceneManager.LoadScene("Level 1-3");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
