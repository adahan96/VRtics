using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SendName : MonoBehaviour
{
    CanvasData cd;
    public bool droppable;
    // Start is called before the first frame update
    void Start()
    {
        cd  = FindObjectOfType(typeof(CanvasData)) as CanvasData;
    }
    void OnVREnter()
    {
        cd.canvasName = this.transform.name;
        cd.droppable = droppable;
    }
}
