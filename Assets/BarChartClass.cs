using ChartAndGraph;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarChartClass : MonoBehaviour
{
    Dictionary<string, bool> Toggle;
    public GameObject DashboardElementBackground;
    public GameObject DashboardElementBackgroundPrefab;
    public GameObject barChart;
    public GameObject BarChartPrefab;
    Dictionary<string, GameObject> onScreen;
    // Start is called before the first frame update
    void Start()
    {
        Toggle = new Dictionary<string, bool>();
        onScreen = new Dictionary<string, GameObject>();
        //   DashboardElementBackground = new GameObject();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CreateBarChart(BarChartSpecifications bcs)
    {
        if (bcs.Parent != null)
        {

            //    if (!Toggle.ContainsKey(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name))
            //    {
            //        string pressedButtonName = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name;
            //       Toggle[pressedButtonName] = false;
            //    }
            //    if (!Toggle[UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name])
            //    {
            var panel = GameObject.Find(bcs.canvas);
            var panel2 = GameObject.Find(bcs.Parent);

            DashboardElementBackground = (GameObject)Instantiate(DashboardElementBackgroundPrefab);
            DashboardElementBackground.transform.SetParent(panel.transform);
            DashboardElementBackground.name = bcs.BarChartName + "Background";
            DashboardElementBackground.transform.localPosition = bcs.Position;
            DashboardElementBackground.transform.rotation = panel.transform.rotation;
            RectTransform rt_back = DashboardElementBackground.GetComponent<RectTransform>();
            rt_back.sizeDelta = bcs.Size + new Vector2(bcs.Size.x * 0.28f, bcs.Size.y * 0.25f);

            barChart = (GameObject)Instantiate(BarChartPrefab);
            RectTransform rt = barChart.GetComponent<RectTransform>();
            rt.sizeDelta = bcs.Size;
            barChart.name = bcs.BarChartName;

            barChart.GetComponent<RectTransform>().SetParent(DashboardElementBackground.transform);
            // if (panel2.transform.parent != panel.transform)
            //  {
            //      DashboardElementBackground.transform.localPosition = bcs.Position;
            //    barChart.GetComponent<RectTransform>().SetPositionAndRotation(panel2.transform.localPosition + bcs.Position, new Quaternion(0, 0, 0, 0));
            //  }
            //  else
            //  {
            //     DashboardElementBackground.transform.localPosition = bcs.Position + panel2.transform.localPosition;
            //  barChart.GetComponent<RectTransform>().SetPositionAndRotation(panel2.transform.localPosition + panel.transform.localPosition + bcs.Position, new Quaternion(0, 0, 0, 0));
            // }
           // barChart.transform.localPosition = bcs.Position;
            barChart.transform.rotation = panel.transform.rotation;

             barChart.transform.localPosition = new Vector3(0, 0, 0);
            barChart.GetComponent<CanvasBarChart>().AxisSeperation = 100f;
            barChart.GetComponent<CanvasBarChart>().BarSeperation = bcs.BarSeperation;
            barChart.GetComponent<CanvasBarChart>().BarSize = bcs.BarSize;
            barChart.GetComponent<ItemLabels>().FontSize = bcs.ItemLabelsFontSize;
            barChart.GetComponent<CategoryLabels>().FontSize = bcs.CategoryLabelsFontSize;
            barChart.GetComponent<GroupLabels>().FontSize = bcs.GroupLabelsFontSize;
            barChart.GetComponent<BarAnimation>().enabled = bcs.BarAnimation;
            barChart.GetComponent<BarFeed>().categories = bcs.categories;
            barChart.GetComponent<BarFeed>().values = bcs.values;

            onScreen[bcs.BarChartName] = barChart;
            onScreen[DashboardElementBackground.name] = DashboardElementBackground;
            //        Toggle[UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name] = true;
            //     }

            //     else
            //    {
            //Destroy the object
            //        Destroy(onScreen[bcs.BarChartName]);
            //Also destroy the background
            //        Destroy(onScreen[bcs.BarChartName + "Background"]);
            //Remove the destroyed objects from the Onscreen dictionary
            //        onScreen.Remove(bcs.BarChartName);
            //        onScreen.Remove(bcs.BarChartName + "Background");
            //Set the buttons state to false indicating that it is not pressed yet
            //       Toggle[UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name] = false;
            //    }
        }
        else
        {
            var panel = GameObject.Find(bcs.canvas);

            DashboardElementBackground = (GameObject)Instantiate(DashboardElementBackgroundPrefab);
            DashboardElementBackground.transform.SetParent(panel.transform);
            DashboardElementBackground.name = bcs.BarChartName + "Background";
            DashboardElementBackground.transform.localPosition = bcs.Position;
            DashboardElementBackground.transform.rotation = panel.transform.rotation;

            RectTransform rt_back = DashboardElementBackground.GetComponent<RectTransform>();
            rt_back.sizeDelta = bcs.Size + new Vector2(bcs.Size.x * 0.28f, bcs.Size.y * 0.25f);

            barChart = (GameObject)Instantiate(BarChartPrefab);
            RectTransform rt = barChart.GetComponent<RectTransform>();
            rt.sizeDelta = bcs.Size;
            barChart.name = bcs.BarChartName;

            barChart.GetComponent<RectTransform>().SetParent(DashboardElementBackground.transform);
            barChart.transform.localPosition = new Vector3(0,0,0);
            barChart.transform.rotation = panel.transform.rotation;
            barChart.GetComponent<CanvasBarChart>().AxisSeperation = 100f;
            barChart.GetComponent<CanvasBarChart>().BarSeperation = bcs.BarSeperation;
            barChart.GetComponent<CanvasBarChart>().BarSize = bcs.BarSize;
            barChart.GetComponent<ItemLabels>().FontSize = bcs.ItemLabelsFontSize;
            barChart.GetComponent<CategoryLabels>().FontSize = bcs.CategoryLabelsFontSize;
            barChart.GetComponent<GroupLabels>().FontSize = bcs.GroupLabelsFontSize;
            barChart.GetComponent<BarAnimation>().enabled = bcs.BarAnimation;
            barChart.GetComponent<BarFeed>().categories = bcs.categories;
            barChart.GetComponent<BarFeed>().values = bcs.values;

        }
        
    }
}
