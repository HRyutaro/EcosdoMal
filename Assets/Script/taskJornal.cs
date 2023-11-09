using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class taskJornal : MonoBehaviour
{
    public static bool pegou;

    void Start()
    {
        pegou = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (pegou == true && Input.GetKeyDown(KeyCode.E))
        {
            GameController.instance.task = 2;
            if(GameController.instance.Dia == 4)
            {
                GameController.instance.ShowInformacao("Que barulho foi esse? Veio dos Corredores");
            }
            Destroy(gameObject);

        }
    }
}
