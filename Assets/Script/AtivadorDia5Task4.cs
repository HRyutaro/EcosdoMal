using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtivadorDia5Task4 : MonoBehaviour
{
    public GameObject garota;
    public AudioSource grito;

    void Start()
    {
       
    }

  
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player") && GameController.instance.task == 3)
        {
            garota.SetActive(true);
            grito.Play();
            GameController.instance.ShowInformacao("'Pai oque você esta fazendo!!'");
            GameController.instance.task = 4;
            Destroy(gameObject);
        }
    }
}
