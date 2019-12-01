using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyCar : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("enter");

        if (other.gameObject.tag == "Destroy")
        {
            Destroy(other.gameObject);
        }
    }
}
