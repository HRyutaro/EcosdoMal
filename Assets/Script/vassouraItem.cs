using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vassouraItem : MonoBehaviour
{
    public GameObject vassoura;
    public GameObject vassouraChao;

    public static bool pegou;
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
            CamConfig.comVassoura = true;
            Player.comVassoura = true;
            Player.cadernoNaMao = false;
            Destroy(gameObject);
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
