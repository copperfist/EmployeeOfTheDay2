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

    private Rigidbody rb;

    private bool isAPressed = false;

    //github update  test


    private void Update()
    {
        PlayerMovement();
    }

    void PlayerMovement()
    {
        float moveVertical = Input.GetAxis("Vertical");
        float moveHorizontal = Input.GetAxis("Horizontal");

        Vector3 newPosition = new Vector3(moveHorizontal, 0.0f, moveVertical);
        transform.LookAt(newPosition + transform.position);
        transform.Translate(newPosition * movementSpeed * Time.deltaTime, Space.World);
    }

    private void OnTriggerStay(Collider other)
    {
        item = other.gameObject;
        rb = item.GetComponent<Rigidbody>();

        if (other.gameObject.tag == "Cube")
        {
            if (Input.GetKey(KeyCode.E))
            {                
                if (isAPressed != true)
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
            }
        }
    }
}



