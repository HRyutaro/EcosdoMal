using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class item : MonoBehaviour
{

    bool podePegar = false;
    public GameObject itemMao;
    public GameObject itemLocal;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (podePegar == true)
        {
            if (GameController.instance.task == 2)
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
