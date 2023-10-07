using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class task2 : MonoBehaviour
{
    public static int lugares = 6;
    BoxCollider col;
    public Text texto;
    public GameObject corte;

    void Start()
    {
        col = gameObject.GetComponent<BoxCollider>();
        col.enabled = false;
        texto.enabled = false;
        corte.SetActive(false);
    }


    void Update()
    {
        if(GameController.instance.task == 3)
        {
            texto.enabled = true;
            col.enabled = true;
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            if(lugares > 1)
            {
                lugares -= 1;
                corte.SetActive(true);
                Destroy(gameObject);
                Destroy(texto);
            }
            else
            {
                GameController.instance.task = 4;
                corte.SetActive(true);
                Destroy(texto);
                Destroy(gameObject);
            }
        }
    }

}
