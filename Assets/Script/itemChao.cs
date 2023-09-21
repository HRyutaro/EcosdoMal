using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemChao : MonoBehaviour
{

    bool podecolocar = false;
    public Collider col;
    public MeshRenderer mesh;
    public GameObject highlight;
    public GameObject maleta;

    public static bool comMaleta = false;
    void Start()
    {
        
    }


    void Update()
    {
        if(podecolocar == true && Input.GetKeyDown(KeyCode.E))
        {
            col.enabled = true;
            mesh.enabled = true;
            GameController.instance.task = 3;
            print("task " + GameController.instance.task);
            Destroy(highlight);
            Destroy(maleta);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
            if (other.CompareTag("Player") && comMaleta == true)
            {
                podecolocar = true;
            }
    }
    private void OnTriggerExit(Collider other)
    {
            if (other.CompareTag("Player") && comMaleta == true)
            {
                podecolocar = false;
            }
    }
}
