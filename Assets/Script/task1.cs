using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class task1 : MonoBehaviour
{
    public static bool podePegar;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (podePegar == true && Input.GetKeyDown(KeyCode.E))
        {
            GameController.instance.task = 3;
            Destroy(gameObject);
        }
    }
}
