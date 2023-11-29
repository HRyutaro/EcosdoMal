using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachadoDia55 : MonoBehaviour
{
    public static bool pegou;

    public GameObject machadoMao;


    void Start()
    {
        
    }


    void Update()
    {
        if(pegou == true)
        {
            machadoMao.SetActive(true);
            Player.comArma = true;
            GameController.instance.task = 3;
            Destroy(gameObject);
        }
    }


}
