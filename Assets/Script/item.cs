using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class item : MonoBehaviour
{

    bool podePegar = false;
    public GameObject itemMao;
    public GameObject itemLocal;
    public int taskAtual = 2;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (podePegar == true)
        {
            if (GameController.instance.task == taskAtual)
            {
                Player.comItem = true;
                itemLocal.SetActive(true);
                itemMao.SetActive(true);
                Destroy(gameObject);
            }
        }
    }

    public void togglePegar()
    {
        podePegar = !podePegar;
    }
}
