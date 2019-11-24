using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PaperBag : MonoBehaviour
{

    public GameObject shopper;
    public GameObject entrance;
    public GameObject currentShopper;
    public Animator paperBagAnimator;

    private AudioSource audio;
    public AudioClip[] itemInBag;
    private AudioClip itemInBagClip;
    

    //Picking items for the bag
    public string[] products = new string[6]; //Holds all product tags
    private int randomIndex;
    public string chosenItem;

    //Waiting till the bag is full before giving points
    private int itemsInBag = 0;
    private int shoppingList;

    public static bool BagIsFull = false;

    //List of UI items
    public GameObject banana;
    public GameObject bread;
    public GameObject ham;
    public GameObject onion;
    public GameObject soup;
    public GameObject tomato;

    public bool uiUpdate = false;

    private void Start()
    {
        banana = GameObject.Find("Banana_UI");
        bread = GameObject.Find("Bread_UI");
        ham = GameObject.Find("Ham_UI");
        onion = GameObject.Find("Onion_UI");
        soup = GameObject.Find("Soup_UI");
        tomato = GameObject.Find("Tomato_UI");

        entrance = GameObject.FindGameObjectWithTag("Entrance");

        audio = gameObject.GetComponent<AudioSource>();

        currentShopper = Instantiate(shopper, entrance.transform.position, entrance.transform.rotation);

        

        MyList();
        FindProducts();

    }


    private void FindProducts() //Picks a random tag for item
    {
        randomIndex = Random.Range(0, products.Length);
        chosenItem = products[randomIndex];

        Item_UI();

        //Debug.Log(chosenItem); //The chosen tag. This needs to be displayed in UI
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

            int index = Random.Range(0, itemInBag.Length);
            itemInBagClip = itemInBag[index];
            audio.clip = itemInBagClip;
            audio.Play();
            paperBagAnimator.SetTrigger("BagAnim");

            Destroy(other.gameObject);//Destory item
            

            if (itemsInBag >= shoppingList)//Shopping list full
            {
               

                itemsInBag = 0;
                Debug.Log("Shopping Bag Full");
                currentShopper.GetComponent<Animator>().SetBool("Leave", true);
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
        BagIsFull = true;


    }

    public void Item_UI()//Check which item is picked and display correct ui
    {
        Image bananaIMG = banana.GetComponent<Image>();
        Image breadIMG = bread.GetComponent<Image>();
        Image hamIMG = ham.GetComponent<Image>();
        Image onionIMG = onion.GetComponent<Image>();
        Image soupIMG = soup.GetComponent<Image>();
        Image tomatoIMG = tomato.GetComponent<Image>();

        if (chosenItem == "Banana")
        {
            Debug.Log("Banana UI");

            bananaIMG.enabled = true;
            breadIMG.enabled = false;
            hamIMG.enabled = false;
            onionIMG.enabled = false;
            soupIMG.enabled = false;
            tomatoIMG.enabled = false;

            uiUpdate = false;

        }
        else if (chosenItem == "Bread")
        {
            Debug.Log("Bread UI");

            bananaIMG.enabled = false;
            breadIMG.enabled = true;
            hamIMG.enabled = false;
            onionIMG.enabled = false;
            soupIMG.enabled = false;
            tomatoIMG.enabled = false;

            uiUpdate = false;

        }
        else if (chosenItem == "Ham")
        {
            //Debug.Log("Ham UI");

            bananaIMG.enabled = false;
            breadIMG.enabled = false;
            hamIMG.enabled = true;
            onionIMG.enabled = false;
            soupIMG.enabled = false;
            tomatoIMG.enabled = false;
            uiUpdate = false;


        }
        else if (chosenItem == "Onion")
        {
            //Debug.Log("Onion UI");

            bananaIMG.enabled = false;
            breadIMG.enabled = false;
            hamIMG.enabled = false;
            onionIMG.enabled = true;
            soupIMG.enabled = false;
            tomatoIMG.enabled = false;
            uiUpdate = false;

        }
        else if (chosenItem == "Soup")
        {
            //Debug.Log("Soup UI");

            bananaIMG.enabled = false;
            breadIMG.enabled = false;
            hamIMG.enabled = false;
            onionIMG.enabled = false;
            soupIMG.enabled = true;
            tomatoIMG.enabled = false;
            uiUpdate = false;

        }
        else //Tomato
        {
            //Debug.Log("Tomato UI");


            bananaIMG.enabled = false;
            breadIMG.enabled = false;
            hamIMG.enabled = false;
            onionIMG.enabled = false;
            soupIMG.enabled = false;
            tomatoIMG.enabled = true;
            uiUpdate = false;

        }
    }
}
