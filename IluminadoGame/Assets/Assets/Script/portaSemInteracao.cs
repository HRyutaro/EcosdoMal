using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class portaSemInteracao : MonoBehaviour
{
    public Animator anim;
    bool abrir;

    void Start()
    {

    }


    void Update()
    {
        if (abrir == true)
        {
            anim.SetFloat("abrirFechar", 1);
        }
        else
        {
            anim.SetFloat("abrirFechar", 0);
        }
    }

    public void Animacao()
    {
        if (abrir == true)
        {
            abrir = false;
        }
        else
        {
            abrir = true;
        }
    }
}
