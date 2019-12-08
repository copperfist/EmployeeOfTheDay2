using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public GameObject respawnPoint;
    public float movementSpeed = 5.0f;
    public Animator playerAnimator;
    public GameObject runDust;
    private bool isMoving = false;

    public AudioSource runSound;

    public string horizontalCtrl = "Horizontal_P1";
    public string verticalCtrl = "Vertical_P1";

    public Rigidbody rb;
    private Rigidbody playerRb;

    public bool isAPressed = false;

    void Start()
    {
        playerRb = gameObject.GetComponent<Rigidbody>();
        gameObject.GetComponentsInChildren<ParticleSystem>();
        runSound = GetComponent<AudioSource>();
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
            runSound.volume = 0;
        }
        else
        {
            playerAnimator.SetBool("Moving", true);
            runSound.volume = 0.4f;
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

        if (Input.GetAxis(verticalCtrl) > -1.0f || Input.GetAxis(horizontalCtrl) > -1.0f)
        {
            isMoving = true;
        }
        else
        {
            isMoving = false;
        }

        if(isMoving == true)
        {
            Vector3 newPosition = new Vector3(moveHorizontal, 0.0f, moveVertical);
            transform.LookAt(newPosition + transform.position);
            transform.Translate(newPosition * movementSpeed * Time.deltaTime, Space.World);
        }
        else
        {
            rb.velocity = Vector3.zero;
        } 
    }

}