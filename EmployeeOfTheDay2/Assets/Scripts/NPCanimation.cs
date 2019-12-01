using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCanimation : MonoBehaviour
{

    public Animator npcAnimator;
    public bool Walking = false;


    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "npcIdleBox")
        {
            npcAnimator.SetBool("Walking", false);
        }

        else
        {
            npcAnimator.SetBool("Walking", true);

        }

        if (other.tag == "npcKillBox")
        {
            Destroy(gameObject);
        }

    }


}
