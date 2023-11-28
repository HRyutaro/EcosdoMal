using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssombracaoCorrendo2 : MonoBehaviour
{
    public float velocidade = 20;
    public bool correr;

    public GameObject mesh;
    public AudioSource som;

    public static int numeroAsombra = 0;
    void Start()
    {

    }


    void Update()
    {
        if (GameController.instance.task == 3)
        {
            mesh.SetActive(true);    
        }
        if(correr == true)
        {
            animacao();
            
            if(numeroAsombra == 1)
            {
                GameController.instance.ShowInformacao("'JA ESTOU MALUCO COM ESSAS COISAS!! VOU ACABAR COM ELAS AGR!!!'");
            }
            else if (numeroAsombra == 3)
            {
                GameController.instance.ShowInformacao("'PARE JA DE CORRER'");
            }
            Destroy(gameObject, 3);
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player") && GameController.instance.task == 3)
        {
            som.Play();
            correr = true;
            numeroAsombra += 1;
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
}
