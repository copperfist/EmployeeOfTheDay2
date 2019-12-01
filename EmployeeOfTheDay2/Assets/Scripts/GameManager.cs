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

    public bool GameOver2 = false;

    private void Update()
    {
        if (GameOver2 == true)
        {
            if (Input.GetButton("Interact_P1"))
            {
                Debug.Log("CLICK BUTTON");
                GameOverUI.SetActive(false);
                GameOverUI2.SetActive(true);
            }
        }
    }

    public IEnumerator EndGame()
    {
        Time.timeScale = 0f;
        TimesUpUI.SetActive(true);
        //AudioListener.pause = true;

        yield return new WaitForSecondsRealtime(3);

        GameOver2 = true;
        TimesUpUI.SetActive(false);
        GameOverUI.SetActive(true);
        ScoreManagerPlayer.EOTD();
    }

    public void EndGame2()
    {

    }
    public void Replay()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MASTER");
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
