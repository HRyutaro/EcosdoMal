using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SujeiraControl : MonoBehaviour
{
    public static int sujeiras;
    public GameObject checklist;

    void Start()
    {
        sujeiras = 0;
    }


    void Update()
    {
        if(sujeiras == 5 && GameController.instance.task == 4)
        {
            GameController.instance.task = 5;
            CaixaDeluz.lightout = true;
            checklist.SetActive(true);
            Destroy(gameObject);
        }
    }
}
