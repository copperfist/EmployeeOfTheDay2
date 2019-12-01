using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSpawnRight : MonoBehaviour
{
    public GameObject car1, car2;

    public float spawnRate = 2f;

    float nextSpawn = 0f;

    int whatToSpawn;

    void Update()
    {


        if (Time.deltaTime > nextSpawn)
        {
            whatToSpawn = Random.Range(1, 3);
            Debug.Log(whatToSpawn);

            switch (whatToSpawn)
            {
                case 1:
                    Instantiate(car1, transform.position, transform.rotation);
                    break;

                case 2:
                    Instantiate(car2, transform.position, transform.rotation);
                    break;
            }
        }

        nextSpawn = Time.deltaTime + spawnRate;
    }
}
