using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NpcBehaviour : MonoBehaviour
{
    public NavMeshAgent agent;
    public GameObject[] targetWaypoints;
    public GameObject[] payAndLeavePoints;


    private GameObject currentWaypoint;

    private int index;
    private int payIndex = 0;
    private float minDistance = 0.5f;
    private float distance;

    private void Start() //Pick a random waypoint to start
    {
        targetWaypoints = GameObject.FindGameObjectsWithTag("targets");
        payAndLeavePoints = GameObject.FindGameObjectsWithTag("PayAndLeave");


        index = Random.Range(0, targetWaypoints.Length);
        currentWaypoint = targetWaypoints[index];
    }


    private void FixedUpdate()
    {
        distance = Vector3.Distance(transform.position, currentWaypoint.transform.position);
        CheckDistanceToWaypoint(distance);

        agent.SetDestination(currentWaypoint.transform.position);

    }

    void CheckDistanceToWaypoint(float currentDistance)
    {
        if (currentDistance <= minDistance)
        {
            SendToTill();
        }
    }
    void SendToTill()
    {
        currentWaypoint = payAndLeavePoints[payIndex];
        payIndex++;

    }
}
