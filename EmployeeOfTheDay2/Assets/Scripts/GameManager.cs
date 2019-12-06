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

    public GameObject starImage1;
    public GameObject starImage2;
    public GameObject starImage3;
    public GameObject starImage4;
    public GameObject starImage5;


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

        if (ScoreManager.score >= 10 && ScoreManager.score <= 40)
        {
            //1 star
            starImage1.SetActive(true);
            starImage2.SetActive(false);
            starImage3.SetActive(false);
            starImage4.SetActive(false);
            starImage5.SetActive(false);

        }
        else if (ScoreManager.score >= 50 && ScoreManager.score <= 70)
        {
            //2 star
            starImage1.SetActive(true);
            starImage2.SetActive(true);
            starImage3.SetActive(false);
            starImage4.SetActive(false);
            starImage5.SetActive(false);
        }
        else if (ScoreManager.score >= 80 && ScoreManager.score <= 100)
        {
            //3 star
            starImage1.SetActive(true);
            starImage2.SetActive(true);
            starImage3.SetActive(true);
            starImage4.SetActive(false);
            starImage5.SetActive(false);
        }
        else if (ScoreManager.score >= 110 && ScoreManager.score <= 140)
        {
            //4 star
            starImage1.SetActive(true);
            starImage2.SetActive(true);
            starImage3.SetActive(true);
            starImage4.SetActive(true);
            starImage5.SetActive(false);
        }
        else if (ScoreManager.score >= 150)
        {
            //5 star
            starImage1.SetActive(true);
            starImage2.SetActive(true);
            starImage3.SetActive(true);
            starImage4.SetActive(true);
            starImage5.SetActive(true);
        }

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
