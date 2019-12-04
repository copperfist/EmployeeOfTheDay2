using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyerWaypoints1 : MonoBehaviour
{
    //public GameObject[] target;
    public float speed;

    //private int current = 0;
    float waypointDistance = 0.3f;

    public GameObject waypoint4;
    public GameObject waypoint5;
    public GameObject waypoint6;

    public Vector3 targetVector;
    public bool newSpawn = true;
    public bool onConveyor = false;



    private Rigidbody itemRB;

    void Start()
    {
        //target = GameObject.FindGameObjectsWithTag("Waypoints");

        itemRB = GetComponent<Rigidbody>();

        targetVector = new Vector3(0.0f, 0.0f, 0.0f);

        waypoint4 = GameObject.Find("Waypoint4");
        waypoint5 = GameObject.Find("Waypoint5");
        waypoint6 = GameObject.Find("Waypoint6");

    }
    void Update()
    {

        GameObject lever = GameObject.Find("Lever2");

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
        if (collision.gameObject.name == "ConveyorMesh2")
        {

            float waypoint1Dist = Vector3.Distance(waypoint4.transform.position, transform.position);
            float waypoint2Dist = Vector3.Distance(waypoint5.transform.position, transform.position);
            float waypoint3Dist = Vector3.Distance(waypoint6.transform.position, transform.position);


            //Move to waypoint 1
            if (newSpawn == true)
            {
                targetVector = waypoint4.transform.position;
            }

            //Move to waypoint 2
            if (waypoint1Dist < waypointDistance)
            {
                //Debug.Log("Going to point 2");
                newSpawn = false;
                targetVector = waypoint5.transform.position;
            }

            //Move to waypoint 3
            if (waypoint2Dist < waypointDistance)
            {
                targetVector = waypoint6.transform.position;
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