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
    public Text TextTelaInfo;
    public string[] tarefas;

    public int task;
    public bool isPause;

    void Start()
    {
        instance = this;
        task = 1;
        print("task " + task);
        TextTelaInfo.enabled = false;
    }


    void Update()
    {
        Task();
        Pause();
    }

    void Task()
    {
        if(task == 1 && task <= tarefas.Length)
        {
            TextTela.text = tarefas[0];
        }
        else if(task == 2 && task <= tarefas.Length)
        {
            TextTela.text = tarefas[1];
        }
        else if (task == 3 && task <= tarefas.Length)
        {
            TextTela.text = tarefas[2];
        }
        else if (task == 4 && task <= tarefas.Length)
        {
            TextTela.text = tarefas[3];
        }
        else if (task == 5 && task <= tarefas.Length)
        {
            TextTela.text = tarefas[3];
        }
    }

    void Pause()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(isPause == false)
            {
                Time.timeScale = 0;
                isPause = true;
            }
            else
            {
                isPause = false;
                Time.timeScale = 1;
            }

        }
    }

    public void ShowInformacao(string x)
    {
        TextTelaInfo.text = x;
        StartCoroutine(habilitarLegenda());
    }

    IEnumerator habilitarLegenda()
    {
        TextTelaInfo.enabled = true;
        yield return new WaitForSeconds(3);
        TextTelaInfo.enabled = false;
        TextTelaInfo.text = "";
    }

}
