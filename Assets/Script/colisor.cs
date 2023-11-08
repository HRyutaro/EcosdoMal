using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colisor : MonoBehaviour
{

    void Start()
    {
        
    }


    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && GameController.instance.task == 2)
        {
            GameController.instance.ShowInformacao("'Acho que o barulho veio do quarto 237, vou dar uma olhada'");
            GameController.instance.task = 3;
            Destroy(gameObject);
        }
    }
}
