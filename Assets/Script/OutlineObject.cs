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
        outline.OutlineWidth = 4;
        outline.OutlineColor = Color.green;
    }

    public void Deselect()
    {
        outline.OutlineWidth = 3;
        outline.OutlineColor = Color.yellow;
    }
}
