using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seating : MonoBehaviour
{
    public bool canLeave = false;
    public bool reachedTill = false;

    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKey(KeyCode.E) && reachedTill == true && GameObject.Find("Till Opperation").GetComponent<PlayerOperatingTill>().isTillActive == true)
        {
            canLeave = true;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("NPC"))
        {
            reachedTill = true;
        }
    }
}