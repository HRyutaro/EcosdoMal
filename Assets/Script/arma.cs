using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arma : MonoBehaviour
{
    public float range = 5;

    AssombracaoCorrendo ativar;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = Vector3.forward;
        Ray theRay = new Ray(transform.position, transform.TransformDirection(direction * range));
        Debug.DrawRay(transform.position, transform.TransformDirection(direction * range), Color.red);

        if (Physics.Raycast(theRay, out RaycastHit hit, range))
        {
            // O raio atingiu um objeto. Você pode acessar informações sobre a colisão a partir de 'hit'.
            Transform objetoAtingido = hit.transform; // Transform do objeto atingido
            Vector3 pontoDeColisao = hit.point; // Ponto de colisão em coordenadas do mundo

            // Verifique se o ponto de colisão está dentro do objeto.
            if (objetoAtingido.CompareTag("Mae"))
            {
                ativar = objetoAtingido.GetComponent<AssombracaoCorrendo>();
                ativar.animacao();
            }
        }
    }


}
