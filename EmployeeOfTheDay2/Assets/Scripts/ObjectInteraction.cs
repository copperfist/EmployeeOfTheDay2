using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectInteraction : MonoBehaviour
{
    public Transform guide;
    public GameObject item;
    public float throwForce = 10.0f;
    public Animator playerAnimator;
    public string interactCtrl = "Interact_P1";
    public bool leverReady = false;
    public bool leverAction = false;
    public ParticleSystem sweat;

    public bool canHold = false;

    private void Update()
    {
        PlayerAnimation();

        if (Input.GetButtonDown(interactCtrl) && canHold == true)
        {
            item.GetComponent<Rigidbody>().useGravity = false;
            item.GetComponent<Rigidbody>().isKinematic = true;

            item.transform.position = guide.transform.position;
            item.transform.rotation = guide.transform.rotation;
            item.transform.parent = transform;
        }

        else if (Input.GetButtonUp(interactCtrl) && canHold == true)
        {
            item.GetComponent<Rigidbody>().useGravity = true;
            item.GetComponent<Rigidbody>().isKinematic = false;
            item.transform.parent = null;
            item.transform.position = guide.transform.position;
            item = null;
        }

        else if (Input.GetButtonDown(interactCtrl) && leverReady == true)
        {
            playerAnimator.SetBool("Lever", true);
            leverAction = true;

        }

        else if (leverReady == false || Input.GetButtonUp(interactCtrl))
        {
            playerAnimator.SetBool("Lever", false);
            leverAction = false;
            sweat.Play();

        }

        if (item == null) //reset when item is destroyed
        {
            canHold = false;
        }

        /*if (Input.GetKey("joystick button 1"))
        {
            rb.AddForce(throwForce, 0f, 0f);
            isAPressed = false;
            item.GetComponent<Rigidbody>().useGravity = true;
            item.GetComponent<Rigidbody>().isKinematic = false;
            item.transform.parent = null;
            item.transform.position = guide.transform.position;
            item = null;
        }*/

    }

    void PlayerAnimation()//Pick u anim
    {
        if (canHold == true)
        {
            playerAnimator.SetBool("Holding", true);
        }

        else
        {
            playerAnimator.SetBool("Holding", false);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Banana" || other.tag == "Bread" || other.tag == "Ham" || other.tag == "Onion" || other.tag == "Tomato" || other.tag == "Soup")
        {
            item = other.gameObject;
            canHold = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Banana" || other.tag == "Bread" || other.tag == "Ham" || other.tag == "Onion" || other.tag == "Tomato" || other.tag == "Soup")
        {
            canHold = false;
        }
    }
}