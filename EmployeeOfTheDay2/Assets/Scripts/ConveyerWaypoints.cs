using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyerWaypoints : MonoBehaviour
{
    public GameObject[] target;
    public float speed;
    
    private int current = 0;
    public float waypointDistance = 0.2f;

    void Start()
    {
        target = GameObject.FindGameObjectsWithTag("Waypoints");
        
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
           

            //Debug.Log("collision with conveyor belt");
            if (transform.position != target[current].transform.position)
            {
                Vector3 pos = Vector3.MoveTowards(transform.position, target[current].transform.position, speed * Time.deltaTime);

                GetComponent<Rigidbody>().MovePosition(pos);

                float dist = Vector3.Distance(target[current].transform.position, transform.position);

                if (dist < waypointDistance)
                {
                    current++;

                }

                if (current == 3)
                {
                    Destroy(gameObject);
                }

            }

            
        }
    }

   

}