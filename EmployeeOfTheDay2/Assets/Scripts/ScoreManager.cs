using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static int score = 0;        // The player's score.

    
    public Text scoreText; // Reference to the Text component.
    public Text scoreGameOver;

    
    void Start()
    {
        // Set up the reference.
        scoreText = GetComponent<Text> ();
        score = 0;

    }


    void Update()
    {
        scoreText.text = score.ToString();
        scoreGameOver.text = score.ToString();
    }
}
