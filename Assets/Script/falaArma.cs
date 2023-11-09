using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class falaArma : MonoBehaviour
{
    public string texto;

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
            GameController.instance.ShowInformacao(texto);
            Destroy(gameObject);
        }
    }
}
