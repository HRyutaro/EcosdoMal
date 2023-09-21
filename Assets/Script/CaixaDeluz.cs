using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaixaDeluz : MonoBehaviour
{
    bool podeUsar = false;
    public Collider col;

    void Start()
    {
        
    }


    void Update()
    {
        if (podeUsar == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                GameController.instance.task = 4;
                print("task " + GameController.instance.task);
                col.enabled = false;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (GameController.instance.whiteCam == false)
        {
            if (other.CompareTag("Player"))
            {
                podeUsar = true;
            }
        }

    }
    private void OnTriggerExit(Collider other)
    {
        if (GameController.instance.whiteCam == false)
        {
            if (other.CompareTag("Player"))
            {
                podeUsar = false;
            }
        }
    }
}
