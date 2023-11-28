using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class portaArmario : MonoBehaviour
{
    public Animator anim;
    public bool abrir;

    private void Update()
    {
        if(abrir)
        {
            anim.SetFloat("abrir", 1);
        }
        else
        {
            anim.SetFloat("abrir", 0);
        }
    }

    public void TogglePorta()
    {
        abrir = !abrir;
    }


}
