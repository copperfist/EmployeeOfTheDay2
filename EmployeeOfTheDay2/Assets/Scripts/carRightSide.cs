using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carRightSide : MonoBehaviour
{
    private float speed = 12f;
   


    private void FixedUpdate()
    {
        transform.Translate(speed * Time.deltaTime, 0, 0);



    }

    private void OnTriggerEnter(Collider other)
    {

        Debug.Log("enter");

        if (other.gameObject.tag == "Destroy")
        {

            Destroy(gameObject);
        }
    }

}
