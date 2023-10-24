using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterDialogo : MonoBehaviour
{
    public string[] speechtxt;

    private DialogoControl dc;

    private bool podeInteragir = false;
    private bool interagiu = false;
    public static bool podeSeguir;

    public int proxSprite = 0;

    private void Start()
    {
        dc = FindObjectOfType<DialogoControl>();
    }
    private void FixedUpdate()
    {
        
    }
    private void Update()
    {
        if (podeInteragir == true)
        {
            if (interagiu == false)
            {
                dc.Speech(speechtxt);
                Player.parado = true;
                interagiu = true;
            }


        }
        if (interagiu == true && podeSeguir == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                ++proxSprite;
                dc.NextSentence();
                podeSeguir = false;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            podeInteragir = true;
            
        }
    }
}
