using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemChao : MonoBehaviour
{
    public int nextTask = 3;
    bool podecolocar = false;
    public GameObject item;
    public GameObject itemMao;
    public GameObject CheckList;

    public int paraTerminar = 1;
    public static int tasksFeitas;
    void Start()
    {
        tasksFeitas = 0;
    }


    void Update()
    {
        if(podecolocar == true)
        {
            ++tasksFeitas;
            Debug.Log("feitas" + tasksFeitas);
            item.SetActive(true);
            itemMao.SetActive(false);
            Player.comItem = false;
            Destroy(gameObject);
            if (paraTerminar == tasksFeitas)
            {
                Destroy(itemMao);
                GameController.instance.task = nextTask;
                CheckList.SetActive(true);
            }
        }

    }

    public void toggleColocar()
    {
        podecolocar = !podecolocar;
    }
}
