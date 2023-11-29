using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemChao : MonoBehaviour
{

    bool podecolocar = false;
    public GameObject item;
    public GameObject itemMao;

    void Start()
    {
        
    }


    void Update()
    {
        if(podecolocar == true)
        {
            ++taskItem.tasksFeitas;
            Debug.Log("feitas" + taskItem.tasksFeitas);
            item.SetActive(true);
            itemMao.SetActive(false);
            Player.comItem = false;
            Destroy(gameObject);
        }

    }

    public void toggleColocar()
    {
        podecolocar = !podecolocar;
    }
}
