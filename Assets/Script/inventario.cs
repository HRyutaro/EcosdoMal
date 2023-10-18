using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class inventario : MonoBehaviour
{
    public static int fosforo;
    public GameObject inv;
    bool showInvetario;
    public Image[] item;

    void Start()
    {
        item[0].enabled = false;
        item[1].enabled = false;
        item[2].enabled = false;
        item[3].enabled = false;
        item[4].enabled = false;
    }

    void Update()
    {
        toggleInventario();
        inventarioControl();
        Usarfosforo();
    }
    void Usarfosforo()
    {
        if(Input.GetKeyDown(KeyCode.R) && Player.comItem == false && Player.parado == false)
        {
            if(fosforo >= 1)
            {
                Player.bateriaAtual += 10;
                fosforo -= 1;
            }
        }
    }

    void inventarioControl()
    {
        if (fosforo == 0)
        {
            item[0].enabled = false;
            item[1].enabled = false;
            item[2].enabled = false;
            item[3].enabled = false;
            item[4].enabled = false;
        }
        else if (fosforo == 1)
        {
            item[0].enabled = true;
            item[1].enabled = false;
            item[2].enabled = false;
            item[3].enabled = false;
            item[4].enabled = false;
        }
        else if (fosforo == 2)
        {
            item[0].enabled = true;
            item[1].enabled = true;
            item[2].enabled = false;
            item[3].enabled = false;
            item[4].enabled = false;
        }
        else if (fosforo == 3)
        {
            item[0].enabled = true;
            item[1].enabled = true;
            item[2].enabled = true;
            item[3].enabled = false;
            item[4].enabled = false;
        }
        else if (fosforo == 4)
        {
            item[0].enabled = true;
            item[1].enabled = true;
            item[2].enabled = true;
            item[3].enabled = true;
            item[4].enabled = false;
        }
        else if (fosforo == 5)
        {
            item[0].enabled = true;
            item[1].enabled = true;
            item[2].enabled = true;
            item[3].enabled = true;
            item[4].enabled = true;
        }
        
    }

    void toggleInventario()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            showInvetario = !showInvetario;
        }
        if (showInvetario == true)
        {
            inv.SetActive(true);
        }
        else
        {
            inv.SetActive(false);
        }
    }


}
