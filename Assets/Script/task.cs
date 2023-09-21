using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class task : MonoBehaviour
{
    bool podeApertar;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (podeApertar == true && Input.GetKeyDown(KeyCode.E))
        {
            GameController.instance.task = 2;
            print("task " + GameController.instance.task);
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            podeApertar = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            podeApertar = false;
        }
    }
}
