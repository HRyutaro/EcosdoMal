using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    public GameObject tutorialCarta;
    bool showTutorial = true;
    bool viuPrimeiro =true;
    public AudioSource som;

    void Start()
    {
        Player.parado = true;
    }

    // Update is called once per frame
    void Update()
    {
        if( viuPrimeiro == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                TogglePegar();
                Player.parado = false;
                viuPrimeiro = false;
            }
        }

        Show();
    }

    public void TogglePegar()
    {
        showTutorial = !showTutorial;
        Player.parado = !Player.parado;
        som.Play();
    }

    public void Show()
    {
        if (showTutorial == false)
        {
            tutorialCarta.SetActive(false);
        }
        else
        {
            tutorialCarta.SetActive(true);
        }
    }
}
