using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController instance;
    public bool whiteCam = false;

    [Header("Missões")]
    public GameObject[] mission;

    public int task;

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
            mission[0].SetActive(true);
            mission[1].SetActive(false);
            mission[2].SetActive(false);
            mission[3].SetActive(false);
        }
        else if(task == 2)
        {
            mission[0].SetActive(false);
            mission[1].SetActive(true);
            mission[2].SetActive(false);
            mission[3].SetActive(false);
        }
        else if(task == 3)
        {
            mission[0].SetActive(false);
            mission[1].SetActive(false);
            mission[2].SetActive(true);
            mission[3].SetActive(false);

            Luz.lightout = true;
        }
        else if (task == 4)
        {
            mission[0].SetActive(false);
            mission[1].SetActive(false);
            mission[2].SetActive(false);
            mission[3].SetActive(true);
            Luz.lightout = false;
            CamConfig.trocarCam = false;
        }
    }
}
