using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    public float movementSpeed = 5.0f;

    //Object interaction
    //public GameObject interactObject;
    //public GameObject tempParent;
    public Transform guide;
    public GameObject item;
    public float throwForce = 10.0f;
    public bool isAPressed = false;
    public bool canHold = true;

    //Movement
    public Animator playerAnimator;
    public GameObject runDust;
    public string horizontalCtrl = "Horizontal_P1";
    public string verticalCtrl = "Vertical_P1";
    public string interactCtrl = "Interact_P1";

    private Rigidbody playerRb;

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

    private void Update()
    {
        if (Input.GetButtonDown(interactCtrl))
        {
            if (!canHold)
            {
                Throw_Drop();
            }
            else
            {
                PickUp();
            }
        }
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


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Banana" || other.gameObject.tag == "Bread" || other.gameObject.tag == "Ham" || other.gameObject.tag == "Onion" || other.gameObject.tag == "Tomato" || other.gameObject.tag == "Soup")
        {

            item = other.gameObject;

            if (!item)
            {
                return;
            }

            /* if (Input.GetButton(interactCtrl)) //Picking up and dropping objects
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
            else if (Input.GetKey("joystick button 1"))
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

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Banana" || other.gameObject.tag == "Bread" || other.gameObject.tag == "Ham" || other.gameObject.tag == "Onion" || other.gameObject.tag == "Tomato" || other.gameObject.tag == "Soup")
        {
            if (canHold)
            {
                item = null;
            }
        }
    }

    private void PickUp()
    {
        if (!item)
        {
            return;
        }
        item.transform.SetParent(guide);
        item.GetComponent<Rigidbody>().useGravity = false;
        item.transform.localRotation = transform.rotation;
        item.transform.position = guide.position;
        canHold = false;
    }
    private void Throw_Drop()
    {
        if (!item)
        {
            return;
        }
        item.GetComponent<Rigidbody>().useGravity = true;
        item = null;
        guide.GetChild(0).gameObject.GetComponent<Rigidbody>().velocity = transform.forward * throwForce;
        guide.GetChild(0).parent = null;
        canHold = true;
    }
}




