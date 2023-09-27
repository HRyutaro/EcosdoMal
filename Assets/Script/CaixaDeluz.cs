using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaixaDeluz : MonoBehaviour
{
    bool podeUsar = false;
    public Collider col;
    public GameObject Cima;
    public GameObject Baixo;

    public static bool lightout = false;

    void Start()
    {

    }


    void Update()
    {
        if (podeUsar == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if(lightout == true)
                {
                    lightout = false;
                }
                else if (lightout == false)
                {
                    lightout = true;
                }
            }
        }
        if (lightout == true)
        {
            Cima.SetActive(false);
            Baixo.SetActive(true);
        }
        else if (lightout == false)
        {
            Cima.SetActive(true);
            Baixo.SetActive(false);
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
