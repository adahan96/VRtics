using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PerfectSquareLayout : MonoBehaviour
{
    int childCount;
    List<Vector3> positions;
    int xPadding;
    int yPadding;
    float a;
    void Start()
    {
        xPadding = 200;
        yPadding = 150;
        a = 0;
        childCount = 0;
        positions = new List<Vector3>();
    }
    void Update()
    {
        if (childCount != transform.childCount)
        {
            positions.Clear();
            childCount = transform.childCount;
            int PS = nextPerfectSquare(childCount);

            a = (this.transform.GetComponent<RectTransform>().rect.width - (2 * xPadding)) / ((int)Math.Sqrt(PS));

            double rowColumn = Math.Sqrt(PS);
            for (int k = 0; k < rowColumn; k++)
            {
                for (int j = 0; j < rowColumn; j++)
                {
                    positions.Add(new Vector3(xPadding, -yPadding, 0) + new Vector3(-this.transform.GetComponent<RectTransform>().rect.width / 2, this.transform.GetComponent<RectTransform>().rect.height / 2, 0) + new Vector3(j * 2 * a, -k * a, 0));
                }
            }

            int i = 0;
            foreach (Transform t in this.transform)
            {
                Debug.Log("safor");
                //      Debug.Log(t.gameObject);
                t.localPosition = positions[i];
                t.localScale = new Vector3((float)(1 / Math.Sqrt(PS)), (float)(1 / Math.Sqrt(PS)), (float)(1 / Math.Sqrt(PS)));
                i++;
            }
        }
    }
    static int nextPerfectSquare(int N)
    {
        if (Math.Floor(Math.Sqrt(N)) == Math.Sqrt(N))
            return N;
        int nextN = (int)Math.Floor(Math.Sqrt(N)) + 1;

        return nextN * nextN;
    }

}
