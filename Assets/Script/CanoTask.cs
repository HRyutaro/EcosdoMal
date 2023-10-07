using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanoTask : MonoBehaviour
{

    void Start()
    {
        
    }


    void Update()
    {
        if(Cano.giradas == 1000)
        {
            GameController.instance.task = 4;
            Destroy(gameObject);
        }
    }
}
