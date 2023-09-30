using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Luz2 : MonoBehaviour
{
    public Light[] luz;
    bool lights;
    public bool podeApertar;
    float intensidadeOriginal;

    public GameObject cima;
    public GameObject baixo;

    void Start()
    {
        intensidadeOriginal = luz[0].intensity;
        intensidadeOriginal = luz[1].intensity;
        intensidadeOriginal = luz[2].intensity;
    }


    void Update()
    {
        if (CaixaDeluz.lightout == true)
        {
            luz[0].intensity = 0;
            luz[1].intensity = 0;
            luz[2].intensity = 0;

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
                luz[0].intensity = intensidadeOriginal;
                luz[1].intensity = intensidadeOriginal;
                luz[2].intensity = intensidadeOriginal;
                cima.SetActive(true);
                baixo.SetActive(false);
            }
            else
            {
                luz[0].intensity = 0;
                luz[1].intensity = 0;
                luz[2].intensity = 0;

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
