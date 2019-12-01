using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkerScript : MonoBehaviour
{

    public GameObject[] walkerPrefab;
    private GameObject currentWalker;


    void Start()
    {
        int walkerIndex = Random.Range(0, walkerPrefab.Length);

        currentWalker = Instantiate(walkerPrefab[walkerIndex], transform.position, transform.rotation);

        currentWalker.transform.parent = this.transform;

    }


}
