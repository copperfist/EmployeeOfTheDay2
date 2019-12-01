using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;

    //public static PauseMenu instance;

    public string pauseCtrl;
    

    public void Update()
    {
        if (Input.GetButtonDown(pauseCtrl))
        {
            if (GameIsPaused)
            {
                Debug.Log("GAME IS NOT PAUSED");
                Resume();
                AudioListener.pause = false;
                
            }
            else
            {
                Pause();
                Debug.Log("PAUSE");
                AudioListener.pause = true;
                
                
            }
        }
        
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
        AudioListener.pause = false;
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Menu");
        Time.timeScale = 1f;
    }

    public void Quit()
    {
        Application.Quit();
    }
}

