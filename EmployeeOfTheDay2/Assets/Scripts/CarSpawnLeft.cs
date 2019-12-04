using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSpawnLeft : MonoBehaviour
{
    public GameObject car1, car2, car3;

    public float spawnRate = 2f;

    float nextSpawn = 0f;

    int whatToSpawn;

    public void Update()
    {

        if (Time.time > nextSpawn)
        {
            whatToSpawn = Random.Range(1, 4);
            //Debug.Log(whatToSpawn);

            switch (whatToSpawn)
            {
                case 1:
                    Instantiate(car1, transform.position, transform.rotation);
                    break;

                case 2:
                    Instantiate(car2, transform.position, transform.rotation);
                    break;
                case 3:
                    Instantiate(car3, transform.position, transform.rotation);
                    break;

            }
                
            nextSpawn = Time.time + spawnRate;
            
            
        }

       
    }
}
