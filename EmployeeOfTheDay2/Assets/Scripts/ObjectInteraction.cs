using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectInteraction : MonoBehaviour
{
    public Transform guide;
    public GameObject item = null;
    public float throwForce = 10.0f;
    public Animator playerAnimator;
    public string interactCtrl = "Interact_P1";
    public bool leverReady = false;
    public bool leverAction = false;
    public ParticleSystem sweat;

    public bool canHold = false;
    public bool isHolding = false;
    public bool isDead = false;


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
            canHold = false;
            isHolding = true;
        }

        else if (Input.GetButtonUp(interactCtrl) && canHold == true)
        {
            DropObject();
            isHolding = false;
        }

        else if (isDead == true && isHolding)
        {
            DropObject();
            isHolding = false;
        }


        else if (Input.GetButtonDown(interactCtrl) && leverReady == true)
        {
            playerAnimator.SetBool("Lever", true);
            sweat.Play();
            leverAction = true;
        }

        else if (leverReady == false || Input.GetButtonUp(interactCtrl))
        {
            playerAnimator.SetBool("Lever", false);
            leverAction = false;
            sweat.Stop();
        }

        if (item == null) //reset when item is destroyed
        {
            canHold = false;
        }

        /*if (Input.GetKey("joystick button 1")) //Throw
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

    public void DropObject()
    {
        item.GetComponent<Rigidbody>().useGravity = true;
        item.GetComponent<Rigidbody>().isKinematic = false;
        item.transform.parent = null;
        item.transform.position = guide.transform.position;
        item = null;
        canHold = true;
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
        if (other.CompareTag("Banana") || other.CompareTag("Bread") || other.CompareTag("Ham") || other.CompareTag("Onion") || other.CompareTag("Tomato") || other.CompareTag("Soup"))
        {
            item = other.gameObject;
            canHold = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Banana") || other.CompareTag("Bread") || other.CompareTag("Ham") || other.CompareTag("Onion") || other.CompareTag("Tomato") || other.CompareTag("Soup"))
        {
            canHold = false;
        }
    }
}