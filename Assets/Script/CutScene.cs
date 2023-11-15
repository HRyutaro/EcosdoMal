using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CutScene : MonoBehaviour
{
    public string proximaFase;
    public float tempoPular;

    void Start()
    {
        Invoke("SkipSolo" ,tempoPular);
    }


    void Update()
    {
        
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Skip();
        }
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Skip();
        }
    }

    void Skip()
    {
        SceneManager.LoadScene(proximaFase);
    }

    void SkipSolo()
    {
        SceneManager.LoadScene(proximaFase);
    }
}
