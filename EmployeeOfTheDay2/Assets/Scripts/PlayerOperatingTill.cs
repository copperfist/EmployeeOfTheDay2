using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOperatingTill : MonoBehaviour
{

    public bool isTillActive = false;

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isTillActive = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isTillActive = false;
        }
    }
}
