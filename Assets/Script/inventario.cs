using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class inventario : MonoBehaviour
{
    public static int fosforo;
    public Text textoHud;

    void Start()
    {


    }

    void Update()
    {
        Usarfosforo();
        AttHudFosforo();
    }
    void Usarfosforo()
    {
        if(Input.GetKeyDown(KeyCode.R) && Player.parado == false)
        {
            if(fosforo >= 1)
            {
                Player.bateriaAtual += 20;
                fosforo -= 1;
            }
        }
    }
    void AttHudFosforo()
    {
        textoHud.text = fosforo.ToString();
    }
}
