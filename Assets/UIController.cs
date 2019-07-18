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

    // TO BE DELETED

    static string[] bNames = { "b1", "button2", "b3", "b4", "b4", "b6", "b7", "b8" };
    List<UnityEngine.Events.UnityAction> ffb = new List<UnityEngine.Events.UnityAction>();
    public static MenuSpecifications ms_child = new MenuSpecifications("MainMenu", "SubMenu1", new string[] { "subButton1", "sb2"}, 2, new Vector2(200, 200), null, new Vector3(-200, 0, 0));

    public void fillDummyVar()
    {
        ffb.Add(() => QuitGame());
        ffb.Add(() => QuitGame());
        ffb.Add(() => CreateScrollBarMenu(ms_child));
        ffb.Add(() => QuitGame());
        ffb.Add(() => QuitGame());
        ffb.Add(() => QuitGame());
        ffb.Add(() => QuitGame());
        ffb.Add(() => QuitGame());
    }

    

    public static string menuName = "MainMenu";
    public static int noOfButtons = 8; // will come from JSON. This is TO BE DELETED.
    public static Vector2 size = new Vector2(200, 200); // will come from JSON. This is TO BE DELETED.
    public GameObject[] buttons;
    public MenuSpecifications MS;
    public static string parent = "Canvas";
    public static Vector3 menuPosition = new Vector3(0, 0, 0); 
    
    // TO BE DELETED

    public UIController()
    {
        //size = new Vector2(200, 600);
       isPressedBefore = new Dictionary<string, bool>();
        onScreen = new Dictionary<string, GameObject>();
        fillDummyVar();
        MS = new MenuSpecifications(parent, menuName, bNames, noOfButtons, size, ffb, menuPosition);
        

    }
    // Start is called before the first frame update
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    void Start()
    {
        menu = new GameObject();
        CreateScrollBarMenu(MS);
     //   GameObject.Find("b3").GetComponent<Button>().onClick.Invoke();

    }

    // Update is called once per frame
    void Update()
    {

    }

    void CreateScrollBarMenu(MenuSpecifications m)
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

                menu.name = m.menuName;
                menu.GetComponent<RectTransform>().SetParent(panel.transform);

                menu.GetComponent<RectTransform>().SetPositionAndRotation(panel.transform.localPosition + panel2.transform.localPosition + m.menuPosition, new Quaternion(0, 0, 0, 0));
                // menu.GetComponent<RectTransform>().SetInsetAndSizeFromParentEdge(RectTransform.Edge.Bottom, 35, 30);
                //menu.GetComponent<RectTransform>().localPosition = panel.transform.localPosition + new Vector3(-200, 0, 0);
                RectTransform rt = menu.GetComponent<RectTransform>();
                rt.sizeDelta = m.size;
                onScreen[m.menuName] = menu;
                addButtonsToMenu(m);
                isPressedBefore[UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name] = true;
            }
            else
            {
                Destroy(onScreen[m.menuName]);
                onScreen.Remove(m.menuName);
                isPressedBefore[UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name] = false;
            }   
        }

        else
        {
            menu = (GameObject)Instantiate(ScrollMenuPrefab);
            var panel = GameObject.Find("Canvas");
            var panel2 = GameObject.Find(m.parent);

            menu.name = m.menuName;
            menu.GetComponent<RectTransform>().SetParent(panel.transform);

            menu.GetComponent<RectTransform>().SetPositionAndRotation(panel.transform.localPosition + m.menuPosition, new Quaternion(0, 0, 0, 0));
            // menu.GetComponent<RectTransform>().SetInsetAndSizeFromParentEdge(RectTransform.Edge.Bottom, 35, 30);
            //menu.GetComponent<RectTransform>().localPosition = panel.transform.localPosition + new Vector3(-200, 0, 0);
            RectTransform rt = menu.GetComponent<RectTransform>();
            rt.sizeDelta = m.size;
            addButtonsToMenu(m);
        }

    }
    public GameObject buttonPrefab;
    void addButtonsToMenu(MenuSpecifications m)
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
            if (ffb != null)
            {
                buttons[i].GetComponent<Button>().onClick.AddListener(ffb[i]);        
            }
        }
       

    }
    public void QuitGame()
    {
        Debug.Log("saaaaaaaaaaaaaaaaa");
        // save any game data here
    #if UNITY_EDITOR
        // Application.Quit() does not work in the editor so
        // UnityEditor.EditorApplication.isPlaying need to be set to false to end the game
        UnityEditor.EditorApplication.isPlaying = false;
    #else
            Application.Quit();
    #endif
    }
}
    