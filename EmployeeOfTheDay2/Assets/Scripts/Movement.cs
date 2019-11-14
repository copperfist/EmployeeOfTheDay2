using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    public float movementSpeed = 5.0f;

    public GameObject interactObject;
    public GameObject tempParent;
    public Transform guide;
    public GameObject item;
    public float throwForce = 10.0f;
    public Animator playerAnimator;
    public GameObject runDust;

    public string horizontalCtrl = "Horizontal_P1";
    public string verticalCtrl = "Vertical_P1";
    public string interactCtrl = "Interact_P1";

    private Rigidbody rb;
    private Rigidbody playerRb;

    public bool isAPressed = false;

    //github update  test

    void Start()
    {
        playerRb = gameObject.GetComponent<Rigidbody>();
        gameObject.GetComponentsInChildren<ParticleSystem>();
    }

    private void FixedUpdate()
    {
        PlayerMovement();
        PlayerAnimation();

    }

    void PlayerAnimation()
    {
        ParticleSystem dust = runDust.GetComponent<ParticleSystem>();


        if (Input.GetAxis(verticalCtrl) == 0 && Input.GetAxis(horizontalCtrl) == 0)
        {
            playerAnimator.SetBool("Moving", false);
            dust.Play();


        }

        else
        {
            playerAnimator.SetBool("Moving", true);
            //dust.Play();

        }

        if (isAPressed == true)
        {
            playerAnimator.SetBool("Holding", true);
        }

        else
        {
            playerAnimator.SetBool("Holding", false);
        } 
    }

    public void PlayerMovement()
    {
        float moveVertical = Input.GetAxis(verticalCtrl);
        float moveHorizontal = Input.GetAxis(horizontalCtrl);

        Vector3 newPosition = new Vector3(moveHorizontal, 0.0f, moveVertical);
        transform.LookAt(newPosition + transform.position);
        transform.Translate(newPosition * movementSpeed * Time.deltaTime, Space.World);
    }


    private void OnTriggerStay(Collider other)
    {

        item = other.gameObject;
        rb = item.GetComponent<Rigidbody>();

        if (item.tag == "Banana" || item.tag == "Bread" || item.tag == "Ham" || item.tag == "Onion" || item.tag == "Tomato" || item.tag == "Soup")
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
}




