using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class TimerGameOver : GameManager
{
    public int countDownStartValue = 240;
    public Text timerUI;
   
    void Start()
    {
        countDownTimer();
    }
    
    public void countDownTimer()
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
            

            gameHasEnded = true;
            StartCoroutine(EndGame());
            //EndGame();
            timerUI.text = "00:00";
            
        }

    }


}
