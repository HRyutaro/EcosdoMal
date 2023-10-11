using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cano : MonoBehaviour
{
    public static float giradas;
    public Outline outline;
    public GameObject checkList;

    void Start()
    {
        outline.GetComponent<Outline>();   
    }

    // Update is called once per frame
    public void Update()
    {
        if(giradas == 500)
        {
            outline.OutlineColor = Color.green;
            checkList.SetActive(true);
        }
    }
}
