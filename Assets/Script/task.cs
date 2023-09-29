using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class task : MonoBehaviour
{
    bool entrou;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (entrou == true)
        {
            GameController.instance.task = 2;
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            entrou = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            entrou = false;
        }
    }
}
