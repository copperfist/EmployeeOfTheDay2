using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPaperBag : MonoBehaviour
{
    public GameObject paperBag;
    private GameObject paperBagClone;

    private bool isBagFull;

    void Start()
    {
        SpawnBag();

        isBagFull = GameObject.Find("PaperBag(Clone)").GetComponent<PaperBag>().makeBag;

    }

    private void Update()
    {
        if (isBagFull == true)
        {
            SpawnBag();
        }
    }
    public void SpawnBag()
    {
        paperBagClone = Instantiate(paperBag, transform.position, transform.rotation);
    }

}
