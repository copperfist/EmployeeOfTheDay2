using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaperBag : MonoBehaviour
{

    public GameObject shopper;
    public GameObject entrance;

    public string[] products = new string[6]; //Holds all product tags

    private int randomIndex;
    private string chosenItem;

    public GameObject item;


    private void Start()
    {        
        Instantiate(shopper, entrance.transform.position, entrance.transform.rotation);

        FindProducts();
    }
    private void FindProducts()
    {
        randomIndex = Random.Range(0, products.Length);
        chosenItem = products[randomIndex];
        
        Debug.Log(chosenItem); //The chosen tag
    }
    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == chosenItem)
        {
            Destroy(other.gameObject);
        }
    }
}
