using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DialogoControl : MonoBehaviour
{
    [Header("Componentes")]
    public GameObject canvasDialogo;
    public Text speechText;
    static public int dialogo = 0;
    public bool onDialogo;
    public bool podeApertar = true;
    public GameObject passarText;

    [Header("Configurações")]
    public float typingSpeed;
    private string[] sentences;
    public int proxSprite;
    private int index;
    public static bool pularDialogoControl;

    public AudioSource grito;
    public AudioSource shotgunSom;

    public GameObject telaPreta;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (onDialogo == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (podeApertar == true)
                {
                    ++proxSprite;
                    NextSentence();
                    podeApertar = false;
                }
            }
        }
    }
    public void Speech(string[] txt)
    {
        canvasDialogo.SetActive(true);
        sentences = txt;
        StartCoroutine(TypeSentence());
        passarText.SetActive(true);

    }
    IEnumerator TypeSentence()
    {
        foreach (char letter in sentences[index].ToCharArray())
        {
            speechText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
        podeApertar = true;
        EnterDialogo.podeSeguir = true;
    }
    public void NextSentence()
    {
        if (speechText.text == sentences[index])
        {
            if (index < sentences.Length - 1)
            {
                index++;
                speechText.text = "";
                StartCoroutine(TypeSentence());
            }
            else
            {
                index = 0;
                onDialogo = false;
                speechText.text = "";
                Player.parado = false;
                canvasDialogo.SetActive(false);
                GameController.instance.isPause = false;
                podeApertar = false;
                EnterDialogo.podeSeguir = false;

                if (GameController.days == 3)
                {
                    GameObject cMorte = GameObject.Find("Crianca");
                    criancaMorte cM = cMorte.GetComponent<criancaMorte>();
                    cM.acabouDialogo();
                }
                else if (GameController.days == 6)
                {
                    telaPreta.SetActive(true);
                    shotgunSom.Play();
                    Invoke("somGrito", 2f);
                    Invoke("som12", 3f);
                    Invoke("TrocarCena", 5f);
                }
            }

        }
    }

    void somGrito()
    {
        grito.Play();
    }
    void som12()
    {
        shotgunSom.Play();
    }

    void TrocarCena()
    {
        SceneManager.LoadScene("Fim");
    }
}
