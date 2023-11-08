using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ativadorMae : MonoBehaviour
{
    public GameObject mae;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameController.instance.task == 4)
        {
            mae.SetActive(true);
        }
    }
}
