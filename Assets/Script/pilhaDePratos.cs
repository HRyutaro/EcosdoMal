using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pilhaDePratos : MonoBehaviour
{
    public GameObject pilhaMao;

    public GameObject pilhaEspalhada;

    public GameObject localPilha;

    public GameObject colocouPilha;

    public static int pilhas;
    public GameObject checklist;

    public bool pegou;
    void Start()
    {
        pilhas = 0;
        pilhaMao.SetActive(false);
    }


    void Update()
    {
        if(pilhas == 2)
        {
            GameController.instance.task = 3;
            checklist.SetActive(true);
            gameObject.SetActive(false);
        }
        if (pegou == true)
        {
            pilhaMao.SetActive(true);
            pilhaEspalhada.SetActive(false);
            Player.comItem = true;
        }
    }

    public void Pegou()
    {
        pegou = true;
    }
    public void colocou()
    {
        pilhaMao.SetActive(false);
        localPilha.SetActive(false);
        colocouPilha.SetActive(true);
        Player.comItem = false;
        ++pilhas;
    }
}
