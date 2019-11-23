using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCanimation : MonoBehaviour
{

    public Animator npcAnimator;
    public Rigidbody rb;
    public float speed;

    void FixedUpdate()
    {
        speed = rb.velocity.magnitude;

        if (speed >= 1)
        {
            npcAnimator.SetBool("Walking", true);

            //Debug.Log("fast");
        }

        else
        {
            npcAnimator.SetBool("Walking", false);

        }
    }
}
