using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyerWaypoints : MonoBehaviour
{
    public GameObject[] target;
    public float speed;

    private int current = 0;

    void Start()
    {
        target = GameObject.FindGameObjectsWithTag("Waypoints");
       // transform.position = target[current].transform.position; 
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

                //Debug.Log(transform.position.x.ToString());
                if (dist < 0.2) 
                {
                    current++;
                   // Debug.Log("next");
                   // Debug.Log(current);
                }

                if(current == 3)
                {
                    Destroy(gameObject);
                }

            }
        }

        //if (dist <)
        //{
        //    Debug.Log("die");
        //    Destroy(gameObject);
        //}
        


    

    }

}