using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    [SerializeField] private GameObject player1;
    [SerializeField] private GameObject player2;
    [SerializeField] private GameObject player3;
    [SerializeField] private GameObject player4;

    private float carSounds;

    //GET PITCH TO RANDOM BETWEEN 0.7 AND 1.2

    //[SerializeField] private Transform respawnPoint;

    private void Start()
    {
        carSounds = gameObject.GetComponent<AudioSource>().pitch;


        carSounds = Random.Range(0.7f, 1.2f);
    }
    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Player 1")
        {
            player1 = other.gameObject;
            player1.GetComponent<Death>().Die();
        }
        if (other.tag == "Player 2")
        {
            player2 = other.gameObject;
            player2.GetComponent<Death>().Die();
        }
        if (other.tag == "Player 3")
        {
            player3 = other.gameObject;
            player3.GetComponent<Death>().Die();
        }
        if (other.tag == "Player 4")
        {
            player4 = other.gameObject;
            player4.GetComponent<Death>().Die();
        }
    }



}
