using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LuzPrincipal : MonoBehaviour
{
    bool entrou = false;
    public Light luz;
    private float intensidadeOriginal;

    void Start()
    {
        intensidadeOriginal = luz.intensity;
    }


    void Update()
    {
        Luz();
    }

    void Luz()
    {
        if(CaixaDeluz.lightout == false)
        {
            if(entrou == true)
            {
                luz.intensity = intensidadeOriginal;
            }
            else
            {
                luz.intensity = 0;
            }
        }
        else
        {
            luz.intensity = 0;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            entrou = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            entrou = false;
        }
    }
}
