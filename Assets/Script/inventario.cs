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
    public static int mao;
    [Header("Caderno")]
    public static bool usarCaderno;

    [Header("Machado")]
    public static bool usarMachado;
    public static bool machadoBloq;
    public GameObject machado;

    [Header("Vassoura")]
    public static bool usarVassoura;
    public static bool vassouraBloq;
    public bool comVassoura;
    public GameObject vassoura;

    void Start()
    {
        item[0].enabled = false;
        item[1].enabled = false;
        item[2].enabled = false;
        item[3].enabled = false;
        item[4].enabled = false;

        machadoBloq = true;
        vassouraBloq = true;

    }

    void Update()
    {
        toggleInventario();
        inventarioControl();
        Usarfosforo();
        trocarMao();
        controleDeMao();
    }
    void Usarfosforo()
    {
        if(Input.GetKeyDown(KeyCode.R) && Player.parado == false)
        {
            if(fosforo >= 1)
            {
                Player.bateriaAtual += 10;
                fosforo -= 1;
            }
        }
    }
    void controleDeMao()
    {
        if(mao == 0)
        {
            usarCaderno = true;
            usarMachado = false;
            usarVassoura = false;
            machado.SetActive(false);
            vassoura.SetActive(false);
        }
        else if (mao == 1)
        {
            usarCaderno = false;
            usarMachado = true;
            usarVassoura = false;
            machado.SetActive(true);
            vassoura.SetActive(false);
        }
        else if (mao == 2)
        {
            usarCaderno = false;
            usarMachado = false;
            usarVassoura = true;
            machado.SetActive(false);
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

    void trocarMao()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            mao = 0;
            vassoura.SetActive(false);
            CamConfig.comVassoura = false;
            Player.comItem = false;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2)&& machadoBloq == false)
        {
            mao = 1;
            vassoura.SetActive(false);
            CamConfig.comVassoura = false;
            Player.comItem = true;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3)&& vassouraBloq == false)
        {
            mao = 2;
            vassoura.SetActive(true);
            CamConfig.comVassoura = true;
            Player.comItem = true;
        }
    }

}
