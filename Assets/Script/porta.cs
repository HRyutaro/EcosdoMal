using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class porta : MonoBehaviour
{
    public Animator anim;
    public Animator anim2;
    bool abrir;

    public AudioSource somAbrir;
    public AudioSource somFechado;

    void Start()
    {

    }


    void Update()
    {

    }

    public void Animacao()
    {
        if(abrir == true)
        {
            abrir = false;
            portaMudar();
        }
        else
        {
            abrir = true;
            portaMudar();
        }
    }

    void portaMudar()
    {
        if (abrir == true)
        {
            somAbrir.Play();
            anim.SetFloat("abrirFechar", 1);
            anim2.SetFloat("abrirFechar", 1);
        }
        else
        {
            somFechado.Play();
            anim.SetFloat("abrirFechar", 0);
            anim2.SetFloat("abrirFechar", 0);
        }
    }
}
