using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pia : MonoBehaviour
{
    public static float giros;
    public GameObject roscaQuebrada;
    public static bool tirou;

    public static float giros1;
    public GameObject roscaQuebrada1;
    public static bool tirou1;

    public GameObject canoQuebrado;
    public static bool podeTirar2;
    public static bool tirou2;


    public GameObject canoConsertado;
    public GameObject roscaConsertado;
    public GameObject roscaConsertado1;


    public static bool colocou;
    public GameObject localroscaConsertado;
    public static float girosC;

    public static bool colocou1;
    public GameObject LocalroscaConsertado1;
    public static float girosC1;


    public static bool colocou2;
    public GameObject localcanoConsertado;

    public bool consertou;
    public GameObject piaconsertada;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        tirar();

        colocar();
        if (girosC >= 500 && girosC1 >= 500)
        {
            consertou = true;
        }

        if(consertou == true)
        {
            GameController.instance.task = 3;
            piaconsertada.SetActive(true);
            Destroy(gameObject);
        }
    }
    void tirar()
    {
        if (tirou == true)
        {
            roscaQuebrada.SetActive(false);
            
        }
        if (tirou1 == true)
        {
            roscaQuebrada1.SetActive(false);
            
        }
        if(tirou == true && tirou1 == true)
        {
            podeTirar2 = true;
        }
        if(tirou2 == true)
        {
            canoQuebrado.SetActive(false);
            
        }
    }

    void colocar()
    {
        if(tirou == true && tirou1 == true && tirou2 == true)
        {
            localroscaConsertado.SetActive(true);
            LocalroscaConsertado1.SetActive(true);
            localcanoConsertado.SetActive(true);
            if(colocou == true)
            {
                roscaConsertado.SetActive(true);
                localroscaConsertado.SetActive(false);
            }
            if (colocou1 == true)
            {
                roscaConsertado1.SetActive(true);
                LocalroscaConsertado1.SetActive(false);
            }
            if (colocou2 == true)
            {
                canoConsertado.SetActive(true);
                localcanoConsertado.SetActive(false);
            }
        }

    }
}
