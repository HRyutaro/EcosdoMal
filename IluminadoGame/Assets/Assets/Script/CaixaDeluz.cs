using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaixaDeluz : MonoBehaviour
{
    public static bool podeUsar = false;
    public Collider col;
    public GameObject Cima;
    public GameObject Baixo;

    public static bool lightout = false;

    void Start()
    {

    }


    void Update()
    {
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

}
