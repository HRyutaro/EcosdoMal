using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class garotaCorrendo : MonoBehaviour
{
    public float velocidade = 15;
    public bool correr;
    public GameObject garota;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (correr == true)
        {
            animacao();
            garota.SetActive(true);
            Destroy(gameObject, 3);
        }
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player") && GameController.instance.task == 4)
        {
            correr = true;
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
