using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject cam1;
    public GameObject cam2;

    private bool trocarCam;

    void Start()
    {
        
    }


    void Update()
    {
        TrocarCamera();
    }

    void TrocarCamera()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            if(trocarCam == false)
            {
                trocarCam = true;
            }
            else
            {
                trocarCam = false;
            }
        }
        if(trocarCam == false)
        {
            cam1.SetActive(true);
            cam2.SetActive(false);
        }
        else
        {
            cam1.SetActive(false);
            cam2.SetActive(true);
        }
    }
}
