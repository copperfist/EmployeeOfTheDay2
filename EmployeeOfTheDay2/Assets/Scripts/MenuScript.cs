using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public GameObject levelPanel;
    public GameObject mainMenuPanel;

    public void StartGame()
    {
        SceneManager.LoadScene("MASTER");
        Time.timeScale = 1f;
    }

    public void LevelSelect()
    {
        mainMenuPanel.SetActive(false);
        levelPanel.SetActive(true);
    }

    public void ExitLevelSelect()
    {
        levelPanel.SetActive(false);
        mainMenuPanel.SetActive(true);
    }

    public void TutorialSelect()
    {
        SceneManager.LoadScene("TutorialLevel");
    }

    public void OneOneSelect()
    {
        SceneManager.LoadScene("MASTER");
        Time.timeScale = 0f;
    }

    public void OneTwoSelect()
    {
        SceneManager.LoadScene("MASTER Level 2");
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
