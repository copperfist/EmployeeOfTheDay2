using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCanimation : MonoBehaviour
{

    public Animator npcAnimator;
    public bool Walking = true;


    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "npcIdleBox")
        {
            npcAnimator.SetBool("Walking", false);
            Walking = false;
        }

        if (other.tag == "npcKillBox")
        {
            Destroy(gameObject);
        }

    }

    private void OnTriggerExit(Collider other)
    {

        if (other.tag == "npcIdleBox")
        {
            npcAnimator.SetBool("Walking", true);
            Walking = true;
        }

    }


}
