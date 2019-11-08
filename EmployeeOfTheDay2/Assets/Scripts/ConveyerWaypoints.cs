using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyerWaypoints : MonoBehaviour
{
    public Transform[] target;
    public float speed;

    private int current;
    //public GameObject trigger; 



    void OnCollisionStay(Collision collision)
    {
        //Check if object meets conveyor belt
        if (collision.gameObject.name == "ConveyorMesh")
        {

            //Debug.Log("collision with conveyor belt");
            if(transform.position != target[current].position)
            {
                Vector3 pos = Vector3.MoveTowards(transform.position, target[current].position, speed * Time.deltaTime);
                GetComponent<Rigidbody>().MovePosition(pos);
            }
            else current = (current + 1) % target.Length;
        }


    

    }

}