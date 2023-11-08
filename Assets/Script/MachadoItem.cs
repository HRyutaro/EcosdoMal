using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachadoItem : MonoBehaviour
{
    bool inferrujado = true;
    public AudioSource somAfiar;
    public GameObject checklist;
    public int afiado;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(inferrujado == false)
        {
            GameController.instance.task = 4;
            checklist.SetActive(true);
            Destroy(gameObject, 1);
        }
    }

    public void afiar()
    {
        if (inferrujado == true)
        {
            if(afiado <= 2)
            {
                somAfiar.Play();
                afiado += 1;
            }
            else
            {
                somAfiar.Play();
                inferrujado = false;
            }
        }
    }
}
