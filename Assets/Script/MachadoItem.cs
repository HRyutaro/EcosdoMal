using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachadoItem : MonoBehaviour
{
    public GameObject machadoInferrujado;
    bool inferrujado = true;

    public GameObject checklist;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(inferrujado == true)
        {
            machadoInferrujado.SetActive(false);
        }
        else
        {
            GameController.instance.task = 4;
            machadoInferrujado.SetActive(true);
            checklist.SetActive(true);
            Destroy(gameObject);
        }
    }

    public void afiar()
    {
        if (inferrujado == true)
        {
            inferrujado = false;
        }
    }
}
