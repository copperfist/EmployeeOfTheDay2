using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    bool gameHasEnded = false;
    public GameObject GameEndUI;

    public void EndGame ()
    {
        if (gameHasEnded == false)
        {
            Debug.Log("Game Over");
            GameEndUI.SetActive(true);
            Time.timeScale = 0f;
            gameHasEnded = true;
        }
        
    }
    public void Replay()
    {
        Time.timeScale = 1f;
        Application.LoadLevel(Application.loadedLevel);
    }
    public void LoadMenu()
    {
        Time.timeScale = 1f;
        Debug.Log("Loading menu");
        SceneManager.LoadScene("Menu");
    }

    public void QuitGame()
    {
        Debug.Log("Quitting game");
        Application.Quit();
    }
}
