using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public bool gameHasEnded;
    public GameObject TimesUpUI;
    public GameObject GameOverUI;
    public GameObject GameOverUI2;
    public TimerGameOver GameObject;
    public string interactCtrl = "Interact_P1";

    void Start()
    {
       
    }

    private void Update()
    {
    }


    public IEnumerator EndGame ()
    {
       
            
            Time.timeScale = 0f;
            TimesUpUI.SetActive(true);

            yield return new WaitForSecondsRealtime(3);
            
            TimesUpUI.SetActive(false);
            GameOverUI.SetActive(true);

            if (Input.anyKey)
            {
                Debug.Log("A key or mouse click has been detected");
                Debug.Log("button pressed");
                GameOverUI.SetActive(false);
                GameOverUI2.SetActive(true);
                Time.timeScale = 0f;
            }

        //if (Input.GetButtonDown(interactCtrl))
        //    {
        //        Debug.Log("button pressed");
        //        GameOverUI.SetActive(false);
        //        GameOverUI2.SetActive(true);
        //        Time.timeScale = 0f;
        //    }
        
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
