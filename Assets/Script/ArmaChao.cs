using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmaChao : MonoBehaviour
{
    public static bool pegou;

    public GameObject Arma;
    public GameObject ArmaNoChao;

    public AudioSource terror;
    void Start()
    {
        
    }

    
    void Update()
    {
        if (pegou == true)
        {
            Arma.SetActive(true);
            ArmaNoChao.SetActive(false);
            CamConfig.comArma = true;
            Player.comArma = true;
            Player.cadernoNaMao = false;
            GameController.instance.task = 4;
            terror.Play();
            Destroy(gameObject);
        }
    }

    public void pegar()
    {
        if (pegou == true)
        {
            pegou = false;
        }
        else
        {
            pegou = true;
        }
    }
}
