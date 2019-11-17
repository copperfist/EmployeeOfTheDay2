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
    public bool isAPressed = false;

    private bool canHold = false;


    void Start()
    {
        gameObject.GetComponentsInChildren<ParticleSystem>();
    }

    private void FixedUpdate()
    {
        PlayerAnimation();

    }

    void PlayerAnimation()//Pick u anim
    {
        if (isAPressed == true)
        {
            playerAnimator.SetBool("Holding", true);
        }

        else
        {
            playerAnimator.SetBool("Holding", false);
        }
    }

    private void Update()
    {
        if (canHold == true)
        {
            if (Input.GetButton(interactCtrl)) //Picking up and dropping objects
            {

                if (isAPressed == false)
                {

                    isAPressed = true;
                    item.GetComponent<Rigidbody>().useGravity = false;
                    item.GetComponent<Rigidbody>().isKinematic = true;

                    item.transform.position = guide.transform.position;
                    item.transform.rotation = guide.transform.rotation;
                    item.transform.parent = transform;
                }
                else
                {
                    isAPressed = false;
                    item.GetComponent<Rigidbody>().useGravity = true;
                    item.GetComponent<Rigidbody>().isKinematic = false;
                    item.transform.parent = null;
                    item.transform.position = guide.transform.position;
                    item = null;
                    canHold = false;
                }
            }
            /*else if (Input.GetKey("joystick button 1"))
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


    }

    private void OnTriggerStay(Collider other)
    {

        item = other.gameObject;
        if (item.tag == "Banana" || item.tag == "Bread" || item.tag == "Ham" || item.tag == "Onion" || item.tag == "Tomato" || item.tag == "Soup")
        {
            canHold = true;
        }
    }
}