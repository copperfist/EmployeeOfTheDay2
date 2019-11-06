using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaperBag : MonoBehaviour
{

    public GameObject shopper;
    public GameObject entrance;


    //Picking items for the bag
    public string[] products = new string[6]; //Holds all product tags
    private int randomIndex;
    private string chosenItem;

    //Waiting till the bag is full before giving points
    private int itemsInBag = 0;
    private int shoppingList;

    public bool makeBag = false;

    public int points = 0;
    private void Start()
    {
        entrance = GameObject.FindGameObjectWithTag("Entrance");

        Instantiate(shopper, entrance.transform.position, entrance.transform.rotation);

        MyList();
        FindProducts();
    }

    private void Update()
    {
  
    }

    private void FindProducts() //Picks a random tag for item
    {
        randomIndex = Random.Range(0, products.Length);
        chosenItem = products[randomIndex];

        Debug.Log(chosenItem); //The chosen tag. This needs to be displayed in UI
    }

    private void MyList()
    {
        shoppingList = Random.Range(1, 4); //Pick number of items within shopping list
    }

    private void OnTriggerStay(Collider other) //Item added to bag
    {
        if (other.gameObject.tag == chosenItem)
        {
            itemsInBag++;
            Destroy(other.gameObject);//Destory item

            FindProducts();

            if (itemsInBag >= shoppingList)//Shopping list full
            {
                points += 10;
                Debug.Log("Shopping Bag Full");

                makeBag = true;

            }
        }

    }
}
