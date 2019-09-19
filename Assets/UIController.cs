using ChartAndGraph;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    Dictionary<string, bool> isPressedBefore;
    Dictionary<string, GameObject> onScreen;
    public GameObject ScrollMenuPrefab;
    public GameObject menu;
    public GameObject barChart;
    public GameObject BarChartPrefab;
    public GameObject graphChart;
    public GameObject GraphChartPrefab;
    public GameObject DashboardElementBackground;
    public GameObject DashboardElementBackgroundPrefab;
    public GameObject DashboardElementBackgroundPrefab1;

    // TO BE DELETED
    
    static string[] bNames = { "Bar Chart 1", "SubMenu", "Quit VRtics", "Dummy Button", "Dummy Button2" , "Dummy Button3" };
    List<UnityEngine.Events.UnityAction> ffb = new List<UnityEngine.Events.UnityAction>();
    List<UnityEngine.Events.UnityAction> ffb2 = new List<UnityEngine.Events.UnityAction>();
    public void fillDummyVar()
    {
        ffb.Add(() => CreateBarChart(bcs));
        ffb.Add(() => CreateScrollBarMenu(ms_child));
        ffb.Add(() => QuitGame());
        ffb.Add(() => QuitGame());
        ffb.Add(() => QuitGame());
        ffb.Add(() => QuitGame());
       

        ffb2.Add(() => CreateGraphChart(gcs));
        ffb2.Add(() => CreateBarChart(bcs2));
    }
    public static MenuSpecifications ms_child;
    public static string menuName = "MainMenu";
    public static int noOfButtons = 6; // will come from JSON. This is TO BE DELETED.
    public static Vector2 size = new Vector2(200, 200); // will come from JSON. This is TO BE DELETED.
    public GameObject[] buttons;
    public MenuSpecifications MS;
    public BarChartSpecifications bcs;
    public BarChartSpecifications bcs2;
    public GraphChartSpecifications gcs;
    public static string parent = "Canvas";
    public static Vector3 menuPosition = new Vector3(0, 0, 0); 
  //  public static AxisFormat af = new AxisFormat();
    
    // TO BE DELETED

    public UIController()
    {
        //size = new Vector2(200, 600);
        isPressedBefore = new Dictionary<string, bool>();
        onScreen = new Dictionary<string, GameObject>();
        fillDummyVar();
        MS = new MenuSpecifications(parent, menuName, bNames, noOfButtons, size, ffb, menuPosition);
        ms_child = new MenuSpecifications("MainMenu", "SubMenu1", new string[] { "Graph Chart 1", "Bar Chart 2" }, 2, new Vector2(200, 200), ffb2, new Vector3(250, 0, 0));
      //  bcs = new BarChartSpecifications(new Vector3(-350, 0, 0), new Vector2(317,317), "BarChart77", 48.77f, 23.77f, 13, 13, 13, true, menuName, "Canvas_Right");
       // bcs2 = new BarChartSpecifications(new Vector3(350, 0, 0), new Vector2(317, 317), "BarChart78", 38.77f, 33.77f, 16, 16, 16, true, "SubMenu1", "Canvas_Right");
        gcs = new GraphChartSpecifications(new Vector3(-250, -350, 0), new Vector2(600, 400), "Ornek Grafik", 2f, 13, AxisFormat.Time, 1f, 12, 2.569, 11.19, "SubMenu1", "Canvas_Right");

    }
    // Start is called before the first frame update
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    void Start()
    {

        //  menu = new GameObject();
        //  CreateScrollBarMenu(MS);
        //    CreateBarChart(bcs);
        //  CreateScrollBarMenu(new MenuSpecifications("Canvas2", "SubMenu1c2", new string[] { "Graph Chart 1", "Bar Chart 2" }, 2, new Vector2(200, 200), ffb2, new Vector3(250, 0, 0)));
        //CreateBarChart(bcs2);
        //  GameObject.Find("SubMenu").GetComponent<Button>().onClick.Invoke();
        //          CreateGraphChart(gcs);
      //  Debug.Log(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name);
   //     Debug.Log("123");
    }

    // Update is called once per frame
    void Update()
    {

    }
    
    public void CreateScrollBarMenu(MenuSpecifications m)
    {
        if (m.parent != "Canvas")
        {
            if (!isPressedBefore.ContainsKey(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name))
            {
                string pressedButtonName = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name;
                isPressedBefore[pressedButtonName] = false;
            }

            if (!isPressedBefore[UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name])
            {
                menu = (GameObject)Instantiate(ScrollMenuPrefab);
                var panel = GameObject.Find("Canvas");
                var panel2 = GameObject.Find(m.parent);

                DashboardElementBackground = (GameObject)Instantiate(DashboardElementBackgroundPrefab);
                DashboardElementBackground.name = m.menuName + "Background";
                DashboardElementBackground.transform.SetParent(panel.transform);
                DashboardElementBackground.transform.SetPositionAndRotation(panel.transform.localPosition + panel2.transform.localPosition + m.menuPosition, new Quaternion(0, 0, 0, 0));
                RectTransform rt_back = DashboardElementBackground.GetComponent<RectTransform>();
                rt_back.sizeDelta = m.size + new Vector2(50, 50);

                menu.name = m.menuName;
                menu.GetComponent<RectTransform>().SetParent(panel.transform);

                menu.GetComponent<RectTransform>().SetPositionAndRotation(panel.transform.localPosition + panel2.transform.localPosition + m.menuPosition, new Quaternion(0, 0, 0, 0));
                RectTransform rt = menu.GetComponent<RectTransform>();
                rt.sizeDelta = m.size;
                onScreen[m.menuName] = menu;
                onScreen[m.menuName + "Background"] = DashboardElementBackground;
                addButtonsToMenu(m);
                isPressedBefore[UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name] = true;
                
            }
            else
            {
                //Destroy the object
                Destroy(onScreen[m.menuName]);
                //Also destroy the background
                Destroy(onScreen[m.menuName + "Background"]);
                //Remove the destroyed objects from the Onscreen dictionary
                onScreen.Remove(m.menuName);
                onScreen.Remove(m.menuName + "Background");
                //Set the buttons state to false indicating that it is not pressed yet
                isPressedBefore[UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name] = false;
            }   
        }

        else
        {
           
            menu = (GameObject)Instantiate(ScrollMenuPrefab);
            var panel = GameObject.Find(m.parent);
            //  var panel2 = GameObject.Find(m.parent);
           
                DashboardElementBackground = (GameObject)Instantiate(DashboardElementBackgroundPrefab);
                DashboardElementBackground.name = m.menuName + "Background";
                DashboardElementBackground.transform.SetParent(panel.transform);
                DashboardElementBackground.transform.SetPositionAndRotation(panel.transform.localPosition + m.menuPosition, new Quaternion(0, 0, 0, 0));
                RectTransform rt_back = DashboardElementBackground.GetComponent<RectTransform>();
                rt_back.sizeDelta = m.size + new Vector2(50, 50);

                menu.name = m.menuName;
                menu.GetComponent<RectTransform>().SetParent(DashboardElementBackground.transform);

                menu.GetComponent<RectTransform>().SetPositionAndRotation(DashboardElementBackground.transform.position + m.menuPosition, new Quaternion(0, 0, 0, 0));
                RectTransform rt = menu.GetComponent<RectTransform>();
                rt.sizeDelta = m.size;

                onScreen[m.menuName] = menu;
                onScreen[m.menuName + "Background"] = DashboardElementBackground;

                addButtonsToMenu(m);

        }

    }
    public void DestroyMenu(MenuSpecifications m)
    {
        //Destroy the object
        Destroy(onScreen[m.menuName]);
        //Also destroy the background
        Destroy(onScreen[m.menuName + "Background"]);
        //Remove the destroyed objects from the Onscreen dictionary
        onScreen.Remove(m.menuName);
        onScreen.Remove(m.menuName + "Background");

    }
    public GameObject buttonPrefab;
    private void addButtonsToMenu(MenuSpecifications m)
    {
        buttons = new GameObject[m.noOfButtons];
        for (int i = 0; i < m.buttonNames.Length; i += 1)
        {
            buttons[i] = (GameObject)Instantiate(buttonPrefab);
            // Instantiate (clone) the prefab    

            var panel = GameObject.Find(m.menuName + "/Viewport/Content");
            buttons[i].name = m.buttonNames[i];
            GameObject.Find(m.buttonNames[i]).GetComponentInChildren<Text>().text = m.buttonNames[i];
            buttons[i].transform.position = panel.transform.position;
            buttons[i].GetComponent<RectTransform>().SetParent(panel.transform);
            RectTransform rt = buttons[i].GetComponent<RectTransform>();
            rt.sizeDelta = new Vector2((m.size.x * 0.85f), m.size.y/8);
            if (m.functionsForButtons != null)
            {
                buttons[i].GetComponent<Button>().onClick.AddListener(m.functionsForButtons[i]);        
            }
        }
       

    }
    
    public void QuitGame()
    {
    #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
    #else
            Application.Quit();
    #endif
    }

    public void CreateBarChart(BarChartSpecifications bcs)
    {

        if (!isPressedBefore.ContainsKey(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name))
        {
            string pressedButtonName = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name;
            isPressedBefore[pressedButtonName] = false;
        }
        if (!isPressedBefore[UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name])
        {
            var panel = GameObject.Find("Canvas");
            var panel2 = GameObject.Find(bcs.Parent);

            DashboardElementBackground = (GameObject)Instantiate(DashboardElementBackgroundPrefab1);
            DashboardElementBackground.transform.SetParent(panel.transform);
            DashboardElementBackground.name = bcs.BarChartName + "Background";

           RectTransform rt_back = DashboardElementBackground.GetComponent<RectTransform>();
            rt_back.sizeDelta = bcs.Size + new Vector2(bcs.Size.x * 0.28f, bcs.Size.y * 0.25f);

            barChart = (GameObject)Instantiate(BarChartPrefab);
            RectTransform rt = barChart.GetComponent<RectTransform>();
            rt.sizeDelta = bcs.Size;
            barChart.name = bcs.BarChartName;

            barChart.GetComponent<RectTransform>().SetParent(panel.transform);
            if (bcs.Parent == "Canvas")
            {
                DashboardElementBackground.transform.SetPositionAndRotation(panel.transform.localPosition + bcs.Position, new Quaternion(0, 0, 0, 0));
                barChart.GetComponent<RectTransform>().SetPositionAndRotation(panel.transform.localPosition + bcs.Position, new Quaternion(0, 0, 0, 0));
            }
            else
            {
                DashboardElementBackground.transform.SetPositionAndRotation(panel2.transform.localPosition + panel.transform.localPosition + bcs.Position, new Quaternion(0, 0, 0, 0));
                barChart.GetComponent<RectTransform>().SetPositionAndRotation(panel2.transform.localPosition + panel.transform.localPosition + bcs.Position, new Quaternion(0, 0, 0, 0));
            }

            barChart.GetComponent<CanvasBarChart>().AxisSeperation = 100f;
            barChart.GetComponent<CanvasBarChart>().BarSeperation = bcs.BarSeperation;
            barChart.GetComponent<CanvasBarChart>().BarSize = bcs.BarSize;
            barChart.GetComponent<ItemLabels>().FontSize = bcs.ItemLabelsFontSize;
            barChart.GetComponent<CategoryLabels>().FontSize = bcs.CategoryLabelsFontSize;
            barChart.GetComponent<GroupLabels>().FontSize = bcs.GroupLabelsFontSize;
            barChart.GetComponent<BarAnimation>().enabled = bcs.BarAnimation;
            onScreen[bcs.BarChartName] = barChart;
            onScreen[DashboardElementBackground.name] = DashboardElementBackground;
            isPressedBefore[UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name] = true;
        }
        else
        {
            //Destroy the object
            Destroy(onScreen[bcs.BarChartName]);
            //Also destroy the background
            Destroy(onScreen[bcs.BarChartName + "Background"]);
            //Remove the destroyed objects from the Onscreen dictionary
            onScreen.Remove(bcs.BarChartName);
            onScreen.Remove(bcs.BarChartName + "Background");
            //Set the buttons state to false indicating that it is not pressed yet
            isPressedBefore[UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name] = false;
        }
    }
    public void CreateGraphChart(GraphChartSpecifications gcs)
    {
        if (!isPressedBefore.ContainsKey(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name))
        {
            string pressedButtonName = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name;
            isPressedBefore[pressedButtonName] = false;
        }
        if (!isPressedBefore[UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name])
        {
            graphChart = (GameObject)Instantiate(GraphChartPrefab);
            RectTransform rt = graphChart.GetComponent<RectTransform>();
            rt.sizeDelta = gcs.Size;
            graphChart.name = gcs.GraphChartName;
            graphChart.GetComponent<Text>().text = gcs.GraphChartName;
            var panel = GameObject.Find("Canvas");

            graphChart.GetComponent<RectTransform>().SetParent(panel.transform);
            if (gcs.Parent == "Canvas")
                graphChart.GetComponent<RectTransform>().SetPositionAndRotation(panel.transform.localPosition + gcs.Position, new Quaternion(0, 0, 0, 0));
            else
            {
                var panel2 = GameObject.Find(gcs.Parent);
                graphChart.GetComponent<RectTransform>().SetPositionAndRotation(panel2.transform.localPosition + panel.transform.localPosition + gcs.Position, new Quaternion(0, 0, 0, 0));
            }
            graphChart.GetComponent<VerticalAxis>().GetComponent<Text>().fontSize = gcs.VerticalAxisFontSize;
            graphChart.GetComponent<HorizontalAxis>().Format = gcs.HorizontalAxisFormat;
            graphChart.GetComponent<HorizontalAxis>().GetComponent<Text>().fontSize = gcs.HorizontalAxisFontSize;
            graphChart.GetComponent<StreamingGraph>().lineThickness = gcs.LineThickness;
            graphChart.GetComponent<StreamingGraph>().pointSize = gcs.PointSize;

            GameObject text = new GameObject();
            text.transform.SetParent(panel.transform);
            Text myText = text.AddComponent<Text>();
            myText.text = gcs.GraphChartName;
            text.transform.SetPositionAndRotation(panel.transform.localPosition + gcs.Position, new Quaternion(0, 0, 0, 0));
            onScreen[gcs.GraphChartName] = graphChart;
            isPressedBefore[UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name] = true;
        }
        else
        {
            //Destroy the object
            Destroy(onScreen[gcs.GraphChartName]);
            //Also destroy the background
          //  Destroy(onScreen[bcs.BarChartName + "Background"]);
            //Remove the destroyed objects from the Onscreen dictionary
            onScreen.Remove(gcs.GraphChartName);
           // onScreen.Remove(bcs.BarChartName + "Background");
            //Set the buttons state to false indicating that it is not pressed yet
            isPressedBefore[UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name] = false;
        }
    }
}
    