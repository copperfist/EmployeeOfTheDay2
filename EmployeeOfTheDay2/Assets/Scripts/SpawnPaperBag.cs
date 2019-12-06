using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPaperBag : MonoBehaviour
{
    public GameObject paperBag;
    private GameObject paperBagClone;

    public AudioSource cashSound; 

    private bool makeNewBag = false;
    public GameObject moneySplash;

    public static int points = 0;

    void Start()
    {
        cashSound = GetComponent<AudioSource>();
        SpawnBag();
    }
    

    public void FixedUpdate()
    {
        makeNewBag = PaperBag.BagIsFull;
        if (makeNewBag == true)
        {
            cashSound.Play();
            Instantiate(moneySplash, transform);            
            ScoreManager.score += 10;
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
        paperBagClone.GetComponent<PaperBag>().CustomerLeave();
        Destroy(paperBagClone);
        yield return new WaitForSeconds(2);
        SpawnBag();
    }
}
