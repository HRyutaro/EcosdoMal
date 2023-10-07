using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Luz : MonoBehaviour
{
    public Light luz;
    bool lights;
    public bool podeApertar;
    float intensidadeOriginal;

    public GameObject cima;
    public GameObject baixo;

    void Start()
    {
        intensidadeOriginal = luz.intensity;
    }


    void Update()
    {
        if(CaixaDeluz.lightout == true)
        {
            luz.intensity = 0;
            if (lights == true)
            {
                cima.SetActive(true);
                baixo.SetActive(false);
            }
            else
            {
                cima.SetActive(false);
                baixo.SetActive(true);
            }
        }
        else
        {
            if (lights == true)
            {
                luz.intensity = intensidadeOriginal;
                cima.SetActive(true);
                baixo.SetActive(false);
            }
            else
            {
                luz.intensity = 0;
                cima.SetActive(false);
                baixo.SetActive(true);
            }
        }

    }

    public void LigaDesliga()
    {
        if (lights == true)
        {
            lights = false;
        }
        else
        {
            lights = true;
        }
    }


}
