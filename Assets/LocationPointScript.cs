using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LocationPointScript : MonoBehaviour
{
    public UIController Uicont;
    // Start is called before the first frame update
    public static string menuName = "MainMenu";
    public static int noOfButtons = 6; // will come from JSON. This is TO BE DELETED.
    public static Vector2 size = new Vector2(200, 200); // will come from JSON. This is TO BE DELETED.
    public static string parent = "Canvas";
    public static Vector3 menuPosition = new Vector3(0, 0, 0);
    List<UnityEngine.Events.UnityAction> ffb = new List<UnityEngine.Events.UnityAction>();
    static string[] bNames = { "Bar Chart 1", "SubMenu", "Quit VRtics", "Dummy Button", "Dummy Button2", "Dummy Button3" };
    public void fillDummyVar()
    {
        ffb.Add(() => Uicont.QuitGame());
        ffb.Add(() => Uicont.QuitGame());
        ffb.Add(() => Uicont.QuitGame());
        ffb.Add(() => Uicont.QuitGame());
        ffb.Add(() => Uicont.QuitGame());
        ffb.Add(() => Uicont.QuitGame());
    }

    MenuSpecifications MS;
    void Start()
    {
        fillDummyVar();
        MS = new MenuSpecifications(parent, menuName, bNames, noOfButtons, size, ffb, menuPosition);
        Debug.Log(OVRGazePointer.instance.transform.position);
        Uicont = FindObjectOfType(typeof(UIController)) as UIController;
        //   Uicont.CreateScrollBarMenu(MS);
      //  OnVRTriggerPressed(new Vector3(0, 0, 0));

    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnVREnter()
    {
     //   Uicont.CreateScrollBarMenu(MS);
        GameObject.Find("HoverText").GetComponent<Text>().text = "Merih Asansör Ankara Press trigger to view graphs";
    }
    void OnVRExit()
    {
        GameObject.Find("HoverText").GetComponent<Text>().text = "";
    }
    void OnVRTriggerPressed(Vector3 RaycastPosition)
    {
        Uicont.CreateScrollBarMenu(MS);
    //  UIController boss = new UIController();
    //  boss.CreateBarChart(new BarChartSpecifications(new Vector3(350, 0, 0), new Vector2(317, 317), "BarChart78", 38.77f, 33.77f, 16, 16, 16, true, "SubMenu1"));
    }
    void OnVRTriggerReleased()
    {
        //    UIController boss = new UIController();
        //    boss.CreateBarChart(new BarChartSpecifications(new Vector3(-350, 0, 0), new Vector2(317, 317), "BarChart78", 38.77f, 33.77f, 16, 16, 16, true, "SubMenu1"));

    }
}