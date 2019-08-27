using ChartAndGraph;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LineChart : MonoBehaviour
{
    Dictionary<string, bool> Toggle;
    Dictionary<string, GameObject> onScreen;
    public GameObject graphChart;
    public GameObject GraphChartPrefab;
    // Start is called before the first frame update
    void Start()
    {
        onScreen = new Dictionary<string, GameObject>();
        Toggle = new Dictionary<string, bool>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CreateLineChart(GraphChartSpecifications gcs)
    {
    //    if (!Toggle.ContainsKey(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name))
    //    {
    //        string pressedButtonName = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name;
    //        Toggle[pressedButtonName] = false;
    //    }
    //    if (!Toggle[UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name])
    //    {
            graphChart = (GameObject)Instantiate(GraphChartPrefab);
            RectTransform rt = graphChart.GetComponent<RectTransform>();
            rt.sizeDelta = gcs.Size;
            graphChart.name = gcs.GraphChartName;
            graphChart.GetComponent<Text>().text = gcs.GraphChartName;
            var panel = GameObject.Find(gcs.Canvas);
            var panel2 = GameObject.Find(gcs.Parent);

            graphChart.GetComponent<RectTransform>().SetParent(panel.transform);
            if (panel2.transform.parent != panel.transform)
                graphChart.transform.localPosition = gcs.Position;
            else
            {
                graphChart.transform.localPosition = gcs.Position + panel2.transform.localPosition;
            }
            graphChart.GetComponent<VerticalAxis>().GetComponent<Text>().fontSize = gcs.VerticalAxisFontSize;
            graphChart.GetComponent<HorizontalAxis>().Format = gcs.HorizontalAxisFormat;
            graphChart.GetComponent<HorizontalAxis>().GetComponent<Text>().fontSize = gcs.HorizontalAxisFontSize;
            graphChart.GetComponent<StreamingGraph>().lineThickness = gcs.LineThickness;
            graphChart.GetComponent<StreamingGraph>().pointSize = gcs.PointSize;
            graphChart.GetComponent<StreamingGraph>().TotalPoints = 3;
        graphChart.GetComponent<StreamingGraph>().categories = new string[] { "sa2", "sa1", "sae"};
            graphChart.transform.rotation = panel.transform.rotation;
            GameObject text = new GameObject();
            text.transform.SetParent(panel.transform);
            Text myText = text.AddComponent<Text>();
            myText.text = gcs.GraphChartName;
            text.transform.SetPositionAndRotation(panel.transform.localPosition + gcs.Position, new Quaternion(0, 0, 0, 0));
            onScreen[gcs.GraphChartName] = graphChart;
     //       Toggle[UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name] = true;
     //   }
    //    else
    //    {
            //Destroy the object
   //         Destroy(onScreen[gcs.GraphChartName]);
            //Also destroy the background
            //  Destroy(onScreen[bcs.BarChartName + "Background"]);
            //Remove the destroyed objects from the Onscreen dictionary
  //          onScreen.Remove(gcs.GraphChartName);
            // onScreen.Remove(bcs.BarChartName + "Background");
            //Set the buttons state to false indicating that it is not pressed yet
    //        Toggle[UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name] = false;
    //    }
    }

}
