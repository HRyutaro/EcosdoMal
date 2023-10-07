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
            if(Input.GetKeyDown(KeyCode.E))
            {
                if(GameController.instance.task == 2)
                {
                    Player.comItem = true;
                    itemLocal.SetActive(true);
                    itemMao.SetActive(true);
                    Destroy(gameObject);
                }
                else if(GameController.instance.task == 1)
                {
                    GameController.instance.ShowInformacao("Primeiro as noticias depois o trabalho");
                }
            }
        }
    }

    public void togglePegar()
    {
        podePegar = !podePegar;
    }
}
