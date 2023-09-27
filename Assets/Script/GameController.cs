using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class GameController : MonoBehaviour
{
    public static GameController instance;
    public bool whiteCam = false;

    [Header("Missões")]
    public Text TextTela;
    public string[] tarefas;

    public int task;
    public 

    void Start()
    {
        instance = this;
        task = 1;
        print("task " + task);
        
    }


    void Update()
    {
        Task();
    }

    void Task()
    {
        if(task == 1)
        {
            TextTela.text = tarefas[0];
        }
        else if(task == 2)
        {
            TextTela.text = tarefas[1];
        }
    }
}
