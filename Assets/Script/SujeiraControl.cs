using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SujeiraControl : MonoBehaviour
{
    public static int sujeiras;
    public GameObject checklist;
    public AudioSource somElevador;
    public GameObject criança;

    void Start()
    {
        sujeiras = 0;
        
    }


    void Update()
    {
        if(sujeiras == 5 && GameController.instance.task == 4)
        {
            Player.comVassoura = false;
            GameController.instance.ShowInformacao("O que é isso? O elevador não está funcionando, vou dar uma olhada");
            criança.SetActive(true);
            somElevador.Play();
            GameController.instance.task = 5;
            checklist.SetActive(true);
            Destroy(gameObject);
        }
    }
}
