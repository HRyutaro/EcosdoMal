using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class criancaMorte : MonoBehaviour
{
    public GameObject morta;
    public GameObject telaPetra;
    public MeshRenderer mesh;
    public AudioSource machado;
    public AudioSource grito;
    public GameObject machadoMao;
   
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void acabouDialogo()
    {
        StartCoroutine(apagao());
        machado.Play();
    }

    IEnumerator apagao()
    {
        telaPetra.SetActive(true);
        yield return new WaitForSeconds(2f);
        grito.Play();
        telaPetra.SetActive(false);
        mesh.enabled = false;
        morta.SetActive(true);
        GameController.instance.task = 6;
        yield return new WaitForSeconds(3f);
        GameController.instance.ShowInformacao("Isso é...? Não não não, são só alucinações, estou bem cansado, quero ir beber um pouco");
        Player.comMachado = true;
        machadoMao.SetActive(true);
        Destroy(gameObject);
    }
}
