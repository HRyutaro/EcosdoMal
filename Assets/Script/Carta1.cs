using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carta1 : MonoBehaviour
{
    bool podePegar;
    bool pegou = false;

    public GameObject Carta1Tela;
    public MeshRenderer Carta1Fisica;

    void Start()
    {
        Carta1Tela.SetActive(false);
    }


    void Update()
    {
        if(podePegar == true && Input.GetKeyDown(KeyCode.E))
        {
            if(pegou == false)
            {
                Carta1Tela.SetActive(false);
                Carta1Fisica.enabled = true;
                pegou = true;
            }
            else if(pegou == true)
            {
                Carta1Tela.SetActive(true);
                Carta1Fisica.enabled = false;
                pegou = false;
                task1.podePegar = true;
            }

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            podePegar = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            podePegar = false;
            Carta1Tela.SetActive(false);
            Carta1Fisica.enabled = true;
            pegou = true;
        }
    }
}
