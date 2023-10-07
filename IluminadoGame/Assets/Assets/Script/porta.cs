using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class porta : MonoBehaviour
{
    public Animator anim;
    public Animator anim2;
    bool abrir;

    void Start()
    {
        
    }


    void Update()
    {
        if(abrir == true)
        {
            anim.SetFloat("abrirFechar", 1);
            anim2.SetFloat("abrirFechar", 1);
        }
        else
        {
            anim.SetFloat("abrirFechar", 0);
            anim2.SetFloat("abrirFechar", 0);
        }
    }

    public void Animacao()
    {
        if(abrir == true)
        {
            abrir = false;
        }
        else
        {
            abrir = true;
        }
    }
}
