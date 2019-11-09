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
    public string chosenItem;

    //Waiting till the bag is full before giving points
    private int itemsInBag = 0;
    private int shoppingList;

    public static bool BagIsFull = false;
    
    public int points = 0;
    private void Start()
    {        
        entrance = GameObject.FindGameObjectWithTag("Entrance");

        Instantiate(shopper, entrance.transform.position, entrance.transform.rotation);

        MyList();
        FindProducts();
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

            if (itemsInBag >= shoppingList)//Shopping list full
            {
                itemsInBag = 0;
                points += 10;

                Debug.Log("Shopping Bag Full");

                CheckPaperBag();
            }
            else
            {
                BagIsFull = false;
                FindProducts();
            }


        }

    }

    public void CheckPaperBag()
    {
        Debug.Log("Checking Paper Bag");

        BagIsFull = true;

        Debug.Log(BagIsFull);
    }
}
