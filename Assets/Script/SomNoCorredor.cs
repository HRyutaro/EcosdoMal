using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SomNoCorredor : MonoBehaviour
{
    public AudioSource som;
    void Start()
    {
        
    }

    void Update()
    {
        if(GameController.instance.task == 2)
        {
            som.Play();
            Destroy(gameObject);
        }
    }
}
