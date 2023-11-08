using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class task1dia5 : MonoBehaviour
{
    public static bool tentouAtivar;
    public AudioSource grito;

    void Start()
    {
        
    }


    void Update()
    {
        if(tentouAtivar == true)
        {
            GameController.instance.task = 2;
            grito.Play();
            Destroy(gameObject);
        }
    }
}
