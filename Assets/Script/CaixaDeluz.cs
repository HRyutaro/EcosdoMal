using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaixaDeluz : MonoBehaviour
{
    public static bool podeUsar = false;
    public Collider col;

    public static bool lightout = false;
    public Animator anim;

    void Start()
    {

    }


    void Update()
    {
        if (GameController.instance.Dia <= 4)
        {
            luz();
        }
        else
        {
            lightout = true;
        }

    }

    void luz()
    {
        if (lightout == true)
        {
            anim.SetBool("ligado", true);
        }
        else if (lightout == false)
        {
            anim.SetBool("ligado", false);
        }
    }
}
