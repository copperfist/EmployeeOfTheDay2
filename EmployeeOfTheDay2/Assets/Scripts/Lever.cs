using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour
{

    public GameObject player;
    public Animator leverAnimator;
    public bool leverAnimate = false;
    public bool leverOn = false;

    public AudioSource leverDown;
    public AudioSource leverUp;

    
   

    private void OnTriggerEnter(Collider other)
    {

        other.GetComponent<ObjectInteraction>().leverReady = true;

    }

    void sound ()
    {
        leverDown.Play();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.GetComponent<ObjectInteraction>().leverAction == true)
        {
            leverAnimator.SetBool("LeverPressed", true);
            leverOn = true;
            leverUp.Play();
            
            

        }

        if (other.GetComponent<ObjectInteraction>().leverAction == false)
        {
            leverAnimator.SetBool("LeverPressed", false);
            leverOn = false;
            Invoke("sound", 1);

        }
    }


    private void OnTriggerExit(Collider other)
    {

        other.GetComponent<ObjectInteraction>().leverReady = false;


    }

}
