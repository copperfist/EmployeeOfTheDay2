using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    public float movementSpeed = 5.0f;
    public Animator playerAnimator;
    public GameObject runDust;

    public string horizontalCtrl = "Horizontal_P1";
    public string verticalCtrl = "Vertical_P1";

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


   
}