using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class TimerGameOver : MonoBehaviour
{
    int countDownStartValue = 240;
    public Text timerUI;
    void Start()
    {
        countDownTimer();
    }
    
    void countDownTimer()
    {
        if (countDownStartValue > 0)
        {
            TimeSpan spanTime = TimeSpan.FromSeconds(countDownStartValue); 
            timerUI.text = "0" + spanTime.Minutes + ":" + spanTime.Seconds;
            if (spanTime.Seconds < 10)
            {
                timerUI.text = "0" + spanTime.Minutes + ":0" + spanTime.Seconds;
            }
            countDownStartValue--;
            Invoke("countDownTimer", 1.0f); 
        }else
        {
            FindObjectOfType<GameManager>().EndGame();
            timerUI.text = "Game Over";
            
        }

    }


}
