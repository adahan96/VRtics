using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollBarMenu : MonoBehaviour
{
    Dictionary<string, bool> Toggle;
    Dictionary<string, GameObject> onScreen;
    public GameObject menu;
    public GameObject ScrollMenuPrefab;
    public GameObject DashboardElementBackground;
    public GameObject DashboardElementBackgroundPrefab;
    public GameObject[] buttons;
    public GameObject buttonPrefab;

    // DUMMY DATA (Will be taken from the database later.)
    public MenuSpecifications MS;
    public static MenuSpecifications ms_child;
    public BarChartSpecifications bcs2;
    public GraphChartSpecifications gcs;
    public BarChartSpecifications bcs;
    public static string parent = "Canvas";
    public static Vector3 menuPosition = new Vector3(0, 0, 0);
    public static string menuName = "MainMenu";
    public static int noOfButtons = 6;
    static string[] bNames = { "Bar Chart 1", "SubMenu", "Quit VRtics", "Dummy Button", "Dummy Button2", "Dummy Button3" };
    public static Vector2 size = new Vector2(200, 200);
    List<UnityEngine.Events.UnityAction> ffb = new List<UnityEngine.Events.UnityAction>();
    List<UnityEngine.Events.UnityAction> ffb2 = new List<UnityEngine.Events.UnityAction>();
    // GameObject BC;
    // GameObject SBM;
    // GameObject LC;
    // GameObject BC2;
    public BarChartClass BC;
 //   public ScrollBarMenu SBM;
    public BarChartClass BC2;
    public LineChart LC;
    // DUMMY DATA (Will be taken from the database later.)

    public void fillDummyVar()
    {
        ffb.Add(() => BC.CreateBarChart(bcs));
        ffb.Add(() => CreateScrollBarMenu(ms_child));
        ffb.Add(() => QuitGame());
        ffb.Add(() => QuitGame());
        ffb.Add(() => QuitGame());
        ffb.Add(() => QuitGame());


        ffb2.Add(() => LC.CreateLineChart(gcs));
        ffb2.Add(() => BC2.CreateBarChart(bcs2));
    }


    // Start is called before the first frame update
    void Start()
    {
        onScreen = new Dictionary<string, GameObject>();
        Toggle = new Dictionary<string, bool>();
        MS = new MenuSpecifications(parent, menuName, bNames, noOfButtons, size, ffb, menuPosition);
        bcs = new BarChartSpecifications(new Vector3(-350, 0, 0), new Vector2(317, 317), "BarChart77", 48.77f, 23.77f, 13, 13, 13, true, menuName, "Canvas_Right");
        bcs2 = new BarChartSpecifications(new Vector3(350, 0, 0), new Vector2(317, 317), "BarChart78", 38.77f, 33.77f, 16, 16, 16, true, "SubMenu1", "Canvas_Right");
        ms_child = new MenuSpecifications("Canvas_Right", "MainMenu", "SubMenu1", new string[] { "Graph Chart 1", "Bar Chart 2" }, 2, new Vector2(200, 200), ffb2, new Vector3(250, 0, 0));
        // BC = new GameObject();
        // BC.AddComponent<BarChartClass>();
        // LC = new GameObject();
        // LC.AddComponent<LineChart>();
        // BC2 = new GameObject();
        // BC2.AddComponent<BarChartClass>();
        // SBM = new GameObject();
        // SBM.AddComponent<ScrollBarMenu>();
        BC = FindObjectOfType(typeof(BarChartClass)) as BarChartClass;
        BC2 = FindObjectOfType(typeof(BarChartClass)) as BarChartClass;
    //    SBM = FindObjectOfType(typeof(ScrollBarMenu)) as ScrollBarMenu;
        LC = FindObjectOfType(typeof(LineChart)) as LineChart;
        fillDummyVar();
        
        //   GameObject BC = new GameObject();

        // CreateScrollBarMenu(MS);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void CreateScrollBarMenu(MenuSpecifications m)
    {
        if (m.parent != null)
        {
            if (!Toggle.ContainsKey(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name))
            {
                string pressedButtonName = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name;
                Toggle[pressedButtonName] = false;
            }

            if (!Toggle[UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name])
            {
                menu = (GameObject)Instantiate(ScrollMenuPrefab);
                var panel = GameObject.Find(m.canvas);
                var panel2 = GameObject.Find(m.parent + "Background");
                

                DashboardElementBackground = (GameObject)Instantiate(DashboardElementBackgroundPrefab);
                DashboardElementBackground.name = m.menuName + "Background";

                DashboardElementBackground.transform.SetParent(panel.transform);

                if (panel2.transform.parent != panel.transform)
                {
                    DashboardElementBackground.transform.localPosition = m.menuPosition;

                    Transform currentCanvas = panel2.transform.parent;
                    Transform focusCanvas = panel.transform;

                    Vector3 curLoc = currentCanvas.position;
                    Quaternion curRot = currentCanvas.rotation;
                    Vector3 focusLoc = focusCanvas.position;
                    Quaternion focusRot = focusCanvas.rotation;

                    currentCanvas.position = focusLoc;
                    currentCanvas.rotation = focusRot;
                    focusCanvas.position = curLoc;
                    focusCanvas.rotation = curRot;

                    
                    

                }                    
                else
                {
                    DashboardElementBackground.transform.localPosition = m.menuPosition + panel2.transform.localPosition;
                }
                    
                DashboardElementBackground.transform.rotation = panel.transform.rotation;
                RectTransform rt_back = DashboardElementBackground.GetComponent<RectTransform>();
                rt_back.sizeDelta = m.size + new Vector2(50, 50);

                menu.name = m.menuName;
                menu.GetComponent<RectTransform>().SetParent(DashboardElementBackground.transform);

                //  menu.GetComponent<RectTransform>().SetPositionAndRotation(panel.transform.localPosition + panel2.transform.localPosition + m.menuPosition, new Quaternion(0, 0, 0, 0));
                menu.GetComponent<RectTransform>().transform.localPosition = new Vector3(0, 0, 0);
                RectTransform rt = menu.GetComponent<RectTransform>();
                rt.sizeDelta = m.size;
                onScreen[m.menuName] = menu;
                onScreen[m.menuName + "Background"] = DashboardElementBackground;
                addButtonsToMenu(m);
                Toggle[UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name] = true;

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
                Toggle[UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name] = false;
            }
        
        }

        else
        {
            menu = (GameObject)Instantiate(ScrollMenuPrefab);
            Debug.Log(menu);
            var panel = GameObject.Find(m.canvas);
            //  var panel2 = GameObject.Find(m.parent);

            DashboardElementBackground = (GameObject)Instantiate(DashboardElementBackgroundPrefab);
            DashboardElementBackground.name = m.menuName + "Background";
            DashboardElementBackground.transform.SetParent(panel.transform);
            DashboardElementBackground.transform.localPosition = m.menuPosition;
            DashboardElementBackground.transform.rotation = panel.transform.rotation;
            RectTransform rt_back = DashboardElementBackground.GetComponent<RectTransform>();
            rt_back.sizeDelta = m.size + new Vector2(m.size.x * 0.2f, m.size.y * 0.2f);

            menu.name = m.menuName;
            menu.GetComponent<RectTransform>().SetParent(DashboardElementBackground.transform);

              menu.GetComponent<RectTransform>().SetPositionAndRotation(DashboardElementBackground.transform.position, new Quaternion(0, 0, 0, 0));
        //    menu.transform.localPosition = new Vector3(0,0,0);
            RectTransform rt = menu.GetComponent<RectTransform>();
            rt.sizeDelta = m.size;

            Debug.Log(menu);
            onScreen[m.menuName] = menu;
            onScreen[m.menuName + "Background"] = DashboardElementBackground;
            addButtonsToMenu(m);

        }
       // BC.CreateBarChart(bcs);
    }
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
            //buttons[i].transform.SetPositionAndRotation(panel.transform.position + m.menuPosition, new Quaternion(0,0,0,0));
            buttons[i].transform.rotation = panel.transform.rotation;
            buttons[i].GetComponent<RectTransform>().SetParent(panel.transform);
            RectTransform rt = buttons[i].GetComponent<RectTransform>();
            rt.sizeDelta = new Vector2((m.size.x * 0.85f), m.size.y / 8);
            if (m.functionsForButtons != null)
            {
                buttons[i].GetComponent<Button>().onClick.AddListener(m.functionsForButtons[i]);
            }
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
    public void QuitGame()
    {
    #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
    #else
                Application.Quit();
    #endif
    }
}
