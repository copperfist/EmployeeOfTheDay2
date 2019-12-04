using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class TimerGameOver : GameManager
{
    public int countDownStartValue = 240;
    public Text timerUI;
    public AudioSource audioHolderP1;
    public AudioSource audioHolderP2;
    public AudioSource audioHolderP3;
    public AudioSource audioHolderP4;

    public AudioSource Tanoy;

    void Start()
    {
        countDownTimer();              
    }
    
    public void countDownTimer()
    {
        if (countDownStartValue == 37)
        {
            Tanoy.Play();
        }
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

            audioHolderP1.Stop();
            audioHolderP2.Stop();
            audioHolderP3.Stop();
            audioHolderP4.Stop();


            gameHasEnded = true;
            StartCoroutine(EndGame());
            //EndGame();
            timerUI.text = "00:00";
            
        }

    }


}
