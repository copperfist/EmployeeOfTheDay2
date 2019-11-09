using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPaperBag : MonoBehaviour
{
    public GameObject paperBag;
    private GameObject paperBagClone;

    private bool makeNewBag = false;



    void Start()
    {
        SpawnBag();
    }
    

    public void Update()
    {
        makeNewBag = PaperBag.BagIsFull;
        if (makeNewBag == true)
        {            

            StartCoroutine(SpawnNewBag());

            PaperBag.BagIsFull = false;
        }
    }
    public void SpawnBag()
    {
        PaperBag.BagIsFull = false;

        paperBagClone = Instantiate(paperBag, transform.position, transform.rotation);

    }

    public IEnumerator SpawnNewBag()
    {

        Debug.Log("Making a new bag");

        Destroy(paperBagClone);

        yield return new WaitForSeconds(2);

        SpawnBag();
    }

}
