using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Luz : MonoBehaviour
{
    public Light luz;
    bool lights;
    bool podeApertar;

    public GameObject cima;
    public GameObject baixo;

    public static bool lightout = false;

    void Start()
    {
        
    }


    void Update()
    {
        if(podeApertar == true && Input.GetKeyDown(KeyCode.E))
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
        if(lightout == true)
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
                luz.intensity = 6.55f;
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

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            podeApertar = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            podeApertar = false;
        }
    }
}
