using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shelf : MonoBehaviour
{
    public Transform guide;
    public GameObject item;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Cube"))
        {
            other.attachedRigidbody.useGravity = false;
            other.attachedRigidbody.isKinematic = true;
            item = other.gameObject;
            item.transform.position = guide.transform.position;
            item.transform.parent = transform;
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Cube"))
        {
            if (other.attachedRigidbody.useGravity == false)
            {
                other.attachedRigidbody.useGravity = true;
            }
            if (other.attachedRigidbody.isKinematic == true)
            {
                other.attachedRigidbody.isKinematic = false;
            }
            item.transform.parent = null;

        }
    }
}
