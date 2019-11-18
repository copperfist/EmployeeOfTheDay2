using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour
{

    public GameObject player;
    public Animator leverAnimator;
    public bool leverAnimate = false;

    private void OnTriggerEnter(Collider other)
    {

        other.GetComponent<ObjectInteraction>().leverReady = true;

    }


    private void OnTriggerStay(Collider other)
    {
        if (other.GetComponent<ObjectInteraction>().leverAction == true)
        {
            leverAnimator.SetBool("LeverPressed", true);

        }

        if (other.GetComponent<ObjectInteraction>().leverAction == false)
        {
            leverAnimator.SetBool("LeverPressed", false);

        }
    }


    private void OnTriggerExit(Collider other)
    {

        other.GetComponent<ObjectInteraction>().leverReady = false;


    }

}
