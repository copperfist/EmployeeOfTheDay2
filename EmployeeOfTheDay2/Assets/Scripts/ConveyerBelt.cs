using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyerBelt : MonoBehaviour
{
    //prefabs
    public GameObject banana, bread, ham, onion, soup, tomato;

    //spawn once every few seconds 
    public float spawnRate = 3f;

    //next spawn time
    float nextSpawn = 0f;

    //random 
    int whatToSpawn;

    public void Update()
    {
        if(Time.time > nextSpawn)
        {
            whatToSpawn = Random.Range(1, 6);

            //which one is it
            Debug.Log(whatToSpawn);

            //instantiate a prefab 
            switch (whatToSpawn)
            {
                case 1:
                    Instantiate(banana, transform.position, Quaternion.identity);
                    break;
                case 2:
                    Instantiate(bread, transform.position, Quaternion.identity);
                    break;
                case 3:
                    Instantiate(ham, transform.position, Quaternion.identity);
                    break;
                case 4:
                    Instantiate(onion, transform.position, Quaternion.identity);
                    break;
                case 5:
                    Instantiate(soup, transform.position, Quaternion.identity);
                    break;
                case 6:
                    Instantiate(tomato, transform.position, Quaternion.identity);
                    break;
            }

            nextSpawn = Time.time + spawnRate; 
        }
    }


}
