using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssombracaoCorrendo : MonoBehaviour
{
    public float velocidade = 10;
    public bool correr;

    public GameObject telaPreta;
    public GameObject morta;
    public GameObject mesh;
    
    public AudioSource tiro;
    public AudioSource grito;

    void Start()
    {
        
    }


    void Update()
    {

        if(correr == true)
        {
            animacao();
        }
    }

    public void animacao()
    {
        // Obtém a posição atual do objeto
        Vector3 posicaoAtual = transform.position;

        // Calcula o deslocamento para frente com base na velocidade
        float deslocamento = velocidade * Time.deltaTime;

        // Atualiza a posição para mover o objeto para frente
        transform.position = posicaoAtual + transform.forward * deslocamento;
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player"))
        {
            tiro.Play();
            StartCoroutine(apagao());
        }
    }

    IEnumerator apagao()
    {
        telaPreta.SetActive(true);
        yield return new WaitForSeconds(1f);
        grito.Play();
        mesh.SetActive(false);
        morta.SetActive(true);
        GameController.instance.task = 5;
        yield return new WaitForSeconds(2f);
        telaPreta.SetActive(false);
        yield return new WaitForSeconds(3f);
        GameController.instance.ShowInformacao("'Estou alucinando de novo, uma bebida é isso que eu preciso'");
        Destroy(gameObject);
    }
}
