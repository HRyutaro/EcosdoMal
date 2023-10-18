using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vassouraItem : MonoBehaviour
{
    public GameObject vassoura;
    public GameObject vassouraChao;
    public GameObject vassouraLocal;

    bool pegou;
    void Start()
    {
        pegou = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (pegou == true)
        {
            vassoura.SetActive(true);
            vassouraChao.SetActive(false);
            vassouraLocal.SetActive(true);
            CamConfig.comVassoura = true;
            Player.comItem = true;
        }
        else
        {
            vassoura.SetActive(false);
            vassouraChao.SetActive(true);
            vassouraLocal.SetActive(false);
            CamConfig.comVassoura = false;
            Player.comItem = false;
        }
    }

    public void pegar()
    {
        if(pegou == true)
        {
            pegou = false;
        }
        else
        {
            pegou = true;
        }
    }
}
