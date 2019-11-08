using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyerWaypoints : MonoBehaviour
{
    public GameObject[] waypoints;
    int current = 0;
    float rotSpeed;
    public float speed;
    float WPradius = 1;
    //public GameObject trigger; 



    void OnCollisionStay(Collision collision)
    {
        //Check if object meets conveyor belt
        if (collision.gameObject.name == "ConveyorMesh")
        {

            //Debug.Log("collision with conveyor belt");

            if (Vector3.Distance(waypoints[current].transform.position, transform.position) < WPradius)
            {
                Debug.Log("moving to waypoint");
                current++;
                if (current >= waypoints.Length)
                {
                    Destroy(gameObject);
                }


            }

            transform.position = Vector3.MoveTowards(transform.position, waypoints[current].transform.position, Time.deltaTime * speed);
        }


    

    }

}