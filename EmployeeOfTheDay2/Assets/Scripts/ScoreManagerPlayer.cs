using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;

public class ScoreManagerPlayer : MonoBehaviour
{
    public static int currentScoreP1 = 0;
    public static int currentScoreP2 = 0;
    public static int currentScoreP3 = 0;
    public static int currentScoreP4 = 0;

    public static int p1Score;
    public static int p2Score;
    public static int p3Score;
    public static int p4Score;

    private static int highestPlayer;

    private static int[] scores = { p1Score, p2Score, p3Score, p4Score };

    public GameObject mikePic;
    public GameObject bunnyPic;
    public GameObject monkeyPic;
    public GameObject sharkPic;

    private static bool p1Win = false;
    private static bool p2Win = false;
    private static bool p3Win = false;
    private static bool p4Win = false;

    private static bool gameOver = false;
    //private void Start()
    //{
    //    mikePic = GameObject.Find("Mike");
    //    bunnyPic = GameObject.Find("Bunny");
    //    monkeyPic = GameObject.Find("Monkey");
    //    sharkPic = GameObject.Find("Shark");
    //}

    //Find the Employee of the day
    public static void EOTD()
    {
        gameOver = true;
        highestPlayer = Mathf.Max(currentScoreP1, currentScoreP2, currentScoreP3, currentScoreP4);

        if (highestPlayer == currentScoreP1)
        {
            Debug.Log("Player 1 wins");
            p1Win = true;
        }
        else if (highestPlayer == currentScoreP2)
        {
            Debug.Log("Player 2 wins");
            p2Win = true;

        }
        else if (highestPlayer == currentScoreP3)
        {
            Debug.Log("Player 3 wins");
            p3Win = true;
        }
        else if (highestPlayer == currentScoreP4)
        {
            Debug.Log("Player 4 wins");
            p4Win = true;
        }
        else
        {
            Debug.Log("No winners");
            return;
        }
    }

    private void Update()
    {
        if (gameOver == true)
        {
            UpdateImage();
        }
        //Debug.Log(mikePic);
    }

    public void UpdateImage()
    {
        if (p1Win == true)
        {
            mikePic.SetActive(true);
            monkeyPic.SetActive(false);
            sharkPic.SetActive(false);
            bunnyPic.SetActive(false);
        }
        else if (p2Win == true)
        {
            mikePic.SetActive(false);
            monkeyPic.SetActive(true);
            sharkPic.SetActive(false);
            bunnyPic.SetActive(false);
        }
        else if (p3Win == true)
        {
            mikePic.SetActive(false);
            monkeyPic.SetActive(false);
            sharkPic.SetActive(true);
            bunnyPic.SetActive(false);
        }
        else if (p4Win == true)
        {
            mikePic.SetActive(false);
            monkeyPic.SetActive(false);
            sharkPic.SetActive(false);
            bunnyPic.SetActive(true);
        }
        else
        {
            return;
        }
    }
}
