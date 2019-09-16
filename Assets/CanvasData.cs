using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasData : MonoBehaviour
{
    public string canvasName;
    public bool droppable;
    // Start is called before the first frame update
    void Start()
    {
        canvasName = "";
        droppable = false;
    }

}
