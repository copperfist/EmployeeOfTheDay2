using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCQueue : MonoBehaviour
{
    public GameObject seat1;
    public GameObject exit;
    public float speed = 2.0f;
    private float step;

    private void Start()
    {

        seat1 = GameObject.FindGameObjectWithTag("Seats");
        exit = GameObject.FindGameObjectWithTag("Exit");
        step = speed * Time.deltaTime;

    }
    private void Update()
    {
        MoveToSeat();

        if (GameObject.Find("Seating").GetComponent<Seating>().canLeave == true && GameObject.Find("Seating").GetComponent<Seating>().reachedTill == true)
        {
            MoveToExit();
        }
    }

    private void MoveToSeat()
    {
        if (GameObject.Find("Seating").GetComponent<Seating>().canLeave == false)
        {
            transform.position = Vector3.MoveTowards(transform.position, seat1.transform.position, step);
        }
    }
    private void MoveToExit()
    {
        transform.position = Vector3.MoveTowards(transform.position, exit.transform.position, step);
    }
}
