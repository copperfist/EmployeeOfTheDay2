using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{
    private float respawnTimer = 5f;
    public bool isHit = false;

    public GameObject respawnPoint;

    public AudioSource carHonk;

    public void Die()
    {
        gameObject.GetComponent<Movement>().playerAnimator.enabled = false;
        gameObject.GetComponent<ObjectInteraction>().enabled = false;
        gameObject.GetComponent<Movement>().enabled = false;
        isHit = true;


        carHonk.Play();
        

        if (gameObject.GetComponent<ObjectInteraction>().canHold == false)
        {
            gameObject.GetComponent<ObjectInteraction>().DropObject();
        }
    }

    public void Alive()
    {
        gameObject.GetComponent<ObjectInteraction>().enabled = true;
        gameObject.GetComponent<Movement>().playerAnimator.enabled = true;
        transform.position = respawnPoint.transform.position;
        gameObject.GetComponent<Movement>().enabled = true;
        isHit = false;
    }


    private void Update()
    {
        if (isHit == true)
        {
            respawnTimer -= Time.deltaTime;
        }

        if (respawnTimer <= 0f)
        {
            Alive();
            respawnTimer = 5f;
        }
    }

}
