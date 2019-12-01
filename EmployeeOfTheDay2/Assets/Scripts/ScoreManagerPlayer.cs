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

    public static GameObject mikePic;
    public static GameObject bunnyPic;
    public static GameObject monkeyPic;
    public static GameObject sharkPic;

    //private void Update()
    //{
    //    scores[p1Score] = currentScoreP1;
    //    scores[p2Score] = currentScoreP2;
    //    scores[p3Score] = currentScoreP3;
    //    scores[p4Score] = currentScoreP4;


    //}

    //Find the Employee of the day
    public static void EOTD()
    {
        

     highestPlayer = Mathf.Max(currentScoreP1, currentScoreP2, currentScoreP3, currentScoreP4);

        if (highestPlayer == currentScoreP1)
        {
            Debug.Log("Player 1 wins");
            mikePic.SetActive(true);
        }
        else if (highestPlayer == currentScoreP2)
        {
            Debug.Log("Player 2 wins");
            monkeyPic.SetActive(true);

        }
        else if (highestPlayer == currentScoreP3)
        {
            Debug.Log("Player 3 wins");
            sharkPic.SetActive(true);
        }
        else if (highestPlayer == currentScoreP4)
        {
            Debug.Log("Player 4 wins");
            bunnyPic.SetActive(true);
        }
        else
        {
            Debug.Log("No winners");
            return;
        }


    }
}
