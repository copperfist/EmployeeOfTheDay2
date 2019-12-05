using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    [SerializeField] private GameObject player;

    [SerializeField] private Transform respawnPoint;

    private void FixedUpdate()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {

        player = collision.gameObject;

        player.GetComponent<Movement>().Die();


    }



}
