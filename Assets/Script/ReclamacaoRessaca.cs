using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReclamacaoRessaca : MonoBehaviour
{
    public string text;

    void Start()
    {
        
    }


    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            GameController.instance.ShowInformacao(text);
        }
    }
}
