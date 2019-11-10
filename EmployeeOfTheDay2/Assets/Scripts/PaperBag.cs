using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    //List of UI items
    public Sprite banana;
    public Sprite bread;
    public Sprite ham;
    public Sprite onion;
    public Sprite soup;
    public Sprite tomato;

    public Image uiHolder; //This will be changing

    private void Start()
    {        
        entrance = GameObject.FindGameObjectWithTag("Entrance");

        Instantiate(shopper, entrance.transform.position, entrance.transform.rotation);

        MyList();
        FindProducts();
    }

    void Update()
    {
        Item_UI();
        Canvas.ForceUpdateCanvases();
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
                Item_UI();
            }


        }

    }
    public void CheckPaperBag()
    {
        Debug.Log("Checking Paper Bag");

        BagIsFull = true;

        Debug.Log(BagIsFull);
    }

    public void Item_UI()//Check which item is picked and display correct ui
    {
        if(chosenItem == "Banana")
        {
            uiHolder.sprite = banana;
            Canvas.ForceUpdateCanvases();
        }
        else if(chosenItem == "Bread")
        {
            uiHolder.sprite = bread;
            Canvas.ForceUpdateCanvases();
        }
        else if(chosenItem == "Ham")
        {
            uiHolder.sprite = ham;
            Canvas.ForceUpdateCanvases();
        }
        else if(chosenItem == "Onion")
        {
            uiHolder.sprite = onion;
            Canvas.ForceUpdateCanvases();
        }
        else if(chosenItem == "Soup")
        {
            uiHolder.sprite = soup; 
            Canvas.ForceUpdateCanvases();
        }
        else
        {
            uiHolder.sprite = tomato;
            Canvas.ForceUpdateCanvases();
        }


    }
}
