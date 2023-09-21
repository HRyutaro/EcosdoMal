using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class item : MonoBehaviour
{

    bool podePegar = false;
    public GameObject itemMao;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (podePegar == true)
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                itemMao.SetActive(true);
                itemChao.comMaleta = true;
                Destroy(gameObject);
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(GameController.instance.whiteCam == false)
        {
            if (other.CompareTag("Player"))
            {
                podePegar = true;
            }
        }

    }
    private void OnTriggerExit(Collider other)
    {
        if (GameController.instance.whiteCam == false)
        {
            if (other.CompareTag("Player"))
            {
                podePegar = false;
            }
        }
    }
}
