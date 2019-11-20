using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public bool gameHasEnded;
    public GameObject TimesUpUI;
    public GameObject GameOverUI;
    public TimerGameOver GameObject;

    void Start()
    {
       
    }

    private void Update()
    {
    }


    public IEnumerator EndGame ()
    {
       
            Debug.Log("Time's Up!");
            TimesUpUI.SetActive(true);
            yield return new WaitForSecondsRealtime(5);
            Debug.Log("done waiting");
            TimesUpUI.SetActive(false);
            GameOverUI.SetActive(true);
            Time.timeScale = 0f;     
    }

    public void EndGame2 ()
    {

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
