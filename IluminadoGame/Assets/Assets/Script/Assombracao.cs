using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Assombracao : MonoBehaviour
{
    public GameObject objeto;
    public GameObject assombracao;
    public int numeroTask;

    void Start()
    {
        assombracao.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (GameController.instance.task == numeroTask)
        {
            assombracao.SetActive(true);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player") && GameController.instance.task == numeroTask)
        {
            Destroy(objeto);
        }
    }
}
