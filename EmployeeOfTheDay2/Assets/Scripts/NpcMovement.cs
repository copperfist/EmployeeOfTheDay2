using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcMovement : MonoBehaviour
{
    public GameObject npcPrefab;
    public Transform spawnpoints;

    public GameObject seat1;
    public GameObject exit;
    public float speed = 2.0f;
    private float step;

    public GameObject[] products;
    public GameObject product;

    private void Start()
    {
        products = GameObject.FindGameObjectsWithTag("Product");
        seat1 = GameObject.FindGameObjectWithTag("Queue");
        exit = GameObject.FindGameObjectWithTag("Exit");
        step = speed * Time.deltaTime;

        ShoppingList();
    }

    private void Update()
    {
        MoveToTill();

        if (GameObject.Find("Seating").GetComponent<Seating>().canLeave == true && GameObject.Find("Queue").GetComponent<Seating>().reachedTill == true)
        {
            MoveToExit();
        }
    }

    private void MoveToTill()
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

    private void ShoppingList()
    {
        product = products[Random.Range(0, products.Length)];

        Debug.Log("I want" + product);
    }
}
