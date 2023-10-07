using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemChao : MonoBehaviour
{

    bool podecolocar = false;
    public GameObject item;
    public GameObject itemMao;
    public GameObject CheckList;

    public static bool comMaleta = false;
    void Start()
    {
        
    }


    void Update()
    {
        if(podecolocar == true && Input.GetKeyDown(KeyCode.E))
        {
            item.SetActive(true);
            CheckList.SetActive(true);
            GameController.instance.task = 3;
            Player.comItem = false;
            Destroy(gameObject);
            Destroy(itemMao);
        }

    }

    public void toggleColocar()
    {
        podecolocar = !podecolocar;
    }
}
