using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class taskItem : MonoBehaviour
{
    public int paraTerminar = 1;
    public static int tasksFeitas;
    public GameObject CheckList;
    public int nextTask = 3;

    void Start()
    {
        tasksFeitas = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (paraTerminar == tasksFeitas)
        {
            GameController.instance.task = nextTask;
            CheckList.SetActive(true);
            Destroy(gameObject, 1);
        }
    }
}
