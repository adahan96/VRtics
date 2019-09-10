using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SendName : MonoBehaviour
{
    CanvasData cd;
    // Start is called before the first frame update
    void Start()
    {
        cd  = FindObjectOfType(typeof(CanvasData)) as CanvasData;
    }
    void Update()
    {
      //  if(isPerfectSquare(transform.childCount - 1))
      //  {
      //      this.transform.GetComponent<myGridLayout>().cellSize = this.transform.GetComponent<myGridLayout>().cellSize / (float)(Math.Sqrt(transform.childCount - 1) + 1);
     //   }
    }
    void OnVREnter()
    {
        cd.canvasName = this.transform.name;
    }
    static bool isPerfectSquare(double x)
    {

        // Find floating point value of 
        // square root of x. 
        double sr = Math.Sqrt(x);

        // If square root is an integer 
        return ((sr - Math.Floor(sr)) == 0);
    }

}
