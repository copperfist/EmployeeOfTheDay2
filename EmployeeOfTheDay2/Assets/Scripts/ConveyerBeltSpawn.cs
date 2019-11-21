using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyerBeltSpawn : ObjectInteraction
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
        if (Time.time > nextSpawn)
        {
            whatToSpawn = Random.Range(1, 7);

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
                    Debug.Log("tomato spawn");
                    break;
             
            }

            nextSpawn = Time.time + spawnRate;
        }

        if (leverAction == true)
        {
            spawnRate = 1f;
        }
    }


}
