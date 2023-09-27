using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LuzFixa : MonoBehaviour
{
    public Light luz;
    private float intensidadeOriginal;
    public float piscarIntervaloMin = 5f;
    public float piscarIntervaloMax = 20f;
    bool piscando;

    void Start()
    {
        intensidadeOriginal = luz.intensity;
        StartCoroutine(PiscarLuz());
    }

    // Update is called once per frame
    void Update()
    {
        Luz();
    }

    void Luz()
    {
        if (CaixaDeluz.lightout == true )
        {
            luz.intensity = 0;
        }
        if (CaixaDeluz.lightout == false)
        {
            if(piscando == false)
            {
                luz.intensity = intensidadeOriginal;
            }
        }
    }
    IEnumerator PiscarLuz()
    {
        if(CaixaDeluz.lightout == false)
        {
            while (true)
            {
                float intervalo = Random.Range(piscarIntervaloMin, piscarIntervaloMax);

                luz.intensity = 0;
                piscando = false;
                yield return new WaitForSeconds(intervalo);
                piscando = true;
                luz.intensity = intensidadeOriginal;
            }
        }
    }

}
