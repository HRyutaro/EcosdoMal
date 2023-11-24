using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutlineObject : MonoBehaviour
{
    Outline outline;

    void Start()
    {
        outline = GetComponent<Outline>();
    }


    void Update()
    {
        
    }

    public void Select()
    {
        outline.OutlineWidth = 10;
        outline.OutlineColor = Color.blue;
    }

    public void Deselect()
    {
        outline.OutlineWidth = 2;
        outline.OutlineColor = Color.yellow;
    }
}
