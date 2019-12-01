using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carLeftSide : MonoBehaviour
{
    private float speed = 12f;
   


    private void FixedUpdate()
    {
        transform.Translate(- speed * Time.deltaTime, 0, 0);



    }

    void OnCollisionEnter()
    {
        

    }


}
