using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jornal : MonoBehaviour
{
    bool pegou = false;

    public GameObject Carta1Tela;
    public MeshRenderer Carta1Fisica;

    void Start()
    {
        Carta1Tela.SetActive(false);
    }


    void Update()
    {
        if (pegou == false)
        {
            Carta1Tela.SetActive(false);
            Carta1Fisica.enabled = true;
        }
        else if (pegou == true)
        {
            Carta1Tela.SetActive(true);
            Carta1Fisica.enabled = false;
            taskJornal.pegou = true;
        }
    }

    public void togglePegar()
    {
        pegou = !pegou;
        Player.parado = !Player.parado;
    }
}
