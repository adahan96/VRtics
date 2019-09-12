using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SendName : MonoBehaviour
{
    CanvasData cd;
    int childCount;
    List<Vector3> positions;
    int xPadding;
    int yPadding;
    float a;
    Vector3 startPoint;
    // Start is called before the first frame update
    void Start()
    {
        startPoint = new Vector3(this.transform.GetComponent<RectTransform>().rect.width / 2, this.transform.GetComponent<RectTransform>().rect.height / 2, 0);
        xPadding = 80;
        yPadding = 60;
        a = 0;
        childCount = 0;
        positions = new List<Vector3>();
        positions.Add(new Vector3(0, 0, 0));
        cd  = FindObjectOfType(typeof(CanvasData)) as CanvasData;
    }
    void Update()
    {
       
        //  if(isPerfectSquare(transform.childCount - 1))
        //  {
        //      this.transform.GetComponent<myGridLayout>().cellSize = this.transform.GetComponent<myGridLayout>().cellSize / (float)(Math.Sqrt(transform.childCount - 1) + 1);
        //   }
        
        if (childCount != transform.childCount)
        {
            //     this.transform.GetComponent<myGridLayout>().cellSize = new Vector2(300, 200);
            positions.Clear();
            childCount = transform.childCount;
            int PS = nextPerfectSquare(childCount);

            a = (this.transform.GetComponent<RectTransform>().rect.width - (2 * xPadding)) / (childCount - 1);
            
            double rowColumn = Math.Sqrt(PS);
            for(int k = 0; k < rowColumn; k++)
            {
                for(int j = 0; j < rowColumn; j++)
                {
                    positions.Add(new Vector3(k*a, j*a, 0));
                }
            }

            Debug.Log(a);
            Debug.Log(positions[1]);


            int i = 0;
            foreach(Transform t in this.transform)
            {
                Debug.Log("safor");
                //      Debug.Log(t.gameObject);
                t.localPosition = positions[i];
                t.localScale = new Vector3(0.4f, 0.4f, 0.4f);
           
                i++;
            }
            
            Debug.Log("sa");
        }
        
    }
    void OnVREnter()
    {
        cd.canvasName = this.transform.name;
    }
    static int nextPerfectSquare(int N)
    {
        int nextN = (int)Math.Floor(Math.Sqrt(N)) + 1;

        return nextN * nextN;
    }

}
