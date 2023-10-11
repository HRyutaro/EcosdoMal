using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReclamacaoRessaca : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            GameController.instance.ShowInformacao("Ai minha cabeça, acho que bebi demais ontem, melhor começar o trabalho");
        }
    }
}
