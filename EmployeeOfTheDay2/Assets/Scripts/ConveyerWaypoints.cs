using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyerWaypoints : MonoBehaviour
{
    //public GameObject[] target;
    public float speed;

    //private int current = 0;
    float waypointDistance = 0.3f;

    public GameObject waypoint1;
    public GameObject waypoint2;
    public GameObject waypoint3;

    public Vector3 targetVector;
    public bool newSpawn = true;
    public bool onConveyor = false;



    private Rigidbody itemRB;

    void Start()
    {
        //target = GameObject.FindGameObjectsWithTag("Waypoints");

        itemRB = GetComponent<Rigidbody>();

        targetVector = new Vector3(0.0f, 0.0f, 0.0f);

        waypoint1 = GameObject.Find("Waypoint1");
        waypoint2 = GameObject.Find("Waypoint2");
        waypoint3 = GameObject.Find("Waypoint3");

    }
    void Update()
    {

        GameObject lever = GameObject.Find("Lever");

        if (lever.GetComponent<Lever>().leverOn == true)
        {
            speed = 4f;

        }

        if (lever.GetComponent<Lever>().leverOn == false)
        {
            speed = 2f;

        }


    }

    void OnCollisionStay(Collision collision)
    {

        //Check if object meets conveyor belt
        if (collision.gameObject.name == "ConveyorMesh")
        {

            float waypoint1Dist = Vector3.Distance(waypoint1.transform.position, transform.position);
            float waypoint2Dist = Vector3.Distance(waypoint2.transform.position, transform.position);
            float waypoint3Dist = Vector3.Distance(waypoint3.transform.position, transform.position);


            //Move to waypoint 1
            if (newSpawn == true)
            {
                targetVector = waypoint1.transform.position;
            }

            //Move to waypoint 2
            if (waypoint1Dist < waypointDistance)
            {
                Debug.Log("Going to point 2");
                newSpawn = false;
                targetVector = waypoint2.transform.position;
            }

            //Move to waypoint 3
            if (waypoint2Dist < waypointDistance)
            {
                targetVector = waypoint3.transform.position;
            }

            if (waypoint3Dist < waypointDistance)
            {
                Destroy(gameObject);
            }
            itemRB.transform.position = Vector3.MoveTowards(transform.position, targetVector, speed * Time.deltaTime);


            Debug.DrawLine(gameObject.transform.position, targetVector);

            // Debug.Log("collision with conveyor belt");


            //if (transform.position != target[current].transform.position)
            //{
            //    Vector3 pos = Vector3.MoveTowards(transform.position, target[current].transform.position, speed * Time.deltaTime);

            //    GetComponent<Rigidbody>().MovePosition(pos);

            //    float dist = Vector3.Distance(target[current].transform.position, transform.position);

            //    if (dist < waypointDistance)
            //    {
            //        current++;
            //    }

            //    if (current == 3)
            //    {
            //        Destroy(gameObject);
            //    }

            //}




        }
    }



}