using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class taskJornal : MonoBehaviour
{
    public static bool pegou;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (pegou == true && Input.GetKeyDown(KeyCode.E))
        {
            GameController.instance.task = 2;
            Destroy(gameObject);
        }
    }
}
