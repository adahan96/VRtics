using ChartAndGraph;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LocationPointScript : MonoBehaviour
{
    public UIController Uicont;
    public BarChartClass BC;
    public ScrollBarMenu SBM;
    public LineChart LC;
    public InfoText IT;
 //   public GraphChartClass GC;
    // Start is called before the first frame update
    public static string menuName = "MainMenu";
    public static int noOfButtons = 4; // will come from JSON. This is TO BE DELETED.
    public static Vector2 size = new Vector2(200, 200); // will come from JSON. This is TO BE DELETED.
    public static string parent = "Canvas_Right";
    public static Vector3 menuPosition = new Vector3(85, 0, 0);
    List<UnityEngine.Events.UnityAction> ffb = new List<UnityEngine.Events.UnityAction>();
    List<UnityEngine.Events.UnityAction> ffb2 = new List<UnityEngine.Events.UnityAction>();
    static string[] bNames = { "Merih_kapı1_sıcaklık1", "Merih_kapı1_titreşim1", "Merih_punch1_sıcaklık1", "Merih_kapı2 _sıcaklık1" };
    public BarChartSpecifications bcs;
    public BarChartSpecifications bcs2;
    public GraphChartSpecifications gcs;
    public GraphChartSpecifications gcs1;
    public GraphChartSpecifications gcs2;
    public GraphChartSpecifications gcs3;
    public InfoTextSpecifications its;
    public InfoTextSpecifications its_child;
    public static MenuSpecifications ms_child;
    public static MenuSpecifications ms_right;
    public void fillDummyVar()
    {
        ffb.Add(() => {  LC.CreateLineChart(gcs); });
        ffb.Add(() => LC.CreateLineChart(gcs1));
        ffb.Add(() => LC.CreateLineChart(gcs2));
        ffb.Add(() => LC.CreateLineChart(gcs3));


        // ffb2.Add(() => GC.CreateGraphChart(gcs));
        ffb2.Add(() => LC.CreateLineChart(gcs));
        ffb2.Add(() => BC.CreateBarChart(bcs2));
    }

    MenuSpecifications MS;
    void Start()
    {
        its = new InfoTextSpecifications("Canvas_Right", "Merih", "Merih_Asansör_hub1", "Kapı ve punch makinasının bağlı olduğu hub ile ilgili sensör bilgilerini içermektedir.", new Vector2(200f, 200f), new Vector3(-211f, 0, 0));
        its_child = new InfoTextSpecifications("MainMenu", "Canvas_Right",  "fam", "fam", "Lorem ipsum dolor sit FAM FAM", new Vector2(100f, 100f), new Vector3(189f, 56f, 0));
        ms_right = new MenuSpecifications("Canvas_Left", "MainMenu", "menunameee", new string[] { "Show Analysis", "Show Analysis 2" }, 2, new Vector2(200, 200), ffb2, new Vector3(250, 0, 0));

        IT = FindObjectOfType(typeof(InfoText)) as InfoText;
        fillDummyVar();
        MS = new MenuSpecifications("Canvas_Right", menuName, bNames, noOfButtons, size, ffb, menuPosition);
        ms_child = new MenuSpecifications("Canvas_Left", "Canvas_Right", "SubMenu1", new string[] { "Graph Chart 1", "Bar Chart 2" }, 2, new Vector2(200, 200), ffb2, new Vector3(250, 0, 0));
        bcs = new BarChartSpecifications(new Vector3(-350, 0, 0), new Vector2(317, 317), "BarChart77", 48.77f, 23.77f, 13, 13, 13, true, menuName, "Canvas_Right");
        bcs2 = new BarChartSpecifications(new Vector3(350, 0, 0), new Vector2(317, 317), "BarChart78", 38.77f, 33.77f, 16, 16, 16, true, "SubMenu1", "Canvas_Right");
        gcs = new GraphChartSpecifications(new Vector3(0, 0, 0), new Vector2(600, 400), "Merih kapı2 sıcaklık", 2f, 13, AxisFormat.Time, 1f, 12, 2.569, 11.19, "Canvas_Right", "Canvas_Left_Left");
        gcs1 = new GraphChartSpecifications(new Vector3(0, 0, 0), new Vector2(600, 400), "Merih kapı1 titreşim", 2f, 13, AxisFormat.Time, 1f, 12, 2.569, 11.19, "Canvas_Right", "Canvas_Left_Left");
        gcs2 = new GraphChartSpecifications(new Vector3(0, 0, 0), new Vector2(600, 400), "Merih punch1 sıcaklık", 2f, 13, AxisFormat.Time, 1f, 12, 2.569, 11.19, "Canvas_Right", "Canvas_Left_Left");
        gcs3 = new GraphChartSpecifications(new Vector3(0, 0, 0), new Vector2(600, 400), "Merih Kapı2 sıcaklık1", 2f, 13, AxisFormat.Time, 1f, 12, 2.569, 11.19, "Canvas_Right", "Canvas_Left_Left");
        Uicont = FindObjectOfType(typeof(UIController)) as UIController;
        BC = FindObjectOfType(typeof(BarChartClass)) as BarChartClass;
        SBM = FindObjectOfType(typeof(ScrollBarMenu)) as ScrollBarMenu;
        LC = FindObjectOfType(typeof(LineChart)) as LineChart;

        //   Uicont.CreateScrollBarMenu(MS);
        //
     //   OnVRTriggerPressed(new Vector3(0, 0, 0));
        //   SBM.CreateScrollBarMenu(MS);
      //  SBM.CreateScrollBarMenu(MS);
       // GameObject.Find("Merih_kapı1_sıcaklık1").GetComponent<Button>().onClick.Invoke();
     

    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnVREnter()
    {
     //   Uicont.CreateScrollBarMenu(MS);
        GameObject.Find("HoverText").GetComponent<Text>().text = "Merih_Asansör_hub1";
    }
    void OnVRExit()
    {
        GameObject.Find("HoverText").GetComponent<Text>().text = "";
    }
    void OnVRTriggerPressed(Vector3 RaycastPosition)
    {
        SBM.CreateScrollBarMenu(MS);
        IT.CreateInfoText(its);

        //  UIController boss = new UIController();
        //  boss.CreateBarChart(new BarChartSpecifications(new Vector3(350, 0, 0), new Vector2(317, 317), "BarChart78", 38.77f, 33.77f, 16, 16, 16, true, "SubMenu1"));
    }
    void OnVRTriggerPressedAgain()
    {
        SBM.DestroyMenu(MS);
        //  UIController boss = new UIController();
        //  boss.CreateBarChart(new BarChartSpecifications(new Vector3(350, 0, 0), new Vector2(317, 317), "BarChart78", 38.77f, 33.77f, 16, 16, 16, true, "SubMenu1"));
    }
    void OnVRTriggerReleased()
    {
        //    UIController boss = new UIController();
        //    boss.CreateBarChart(new BarChartSpecifications(new Vector3(-350, 0, 0), new Vector2(317, 317), "BarChart78", 38.77f, 33.77f, 16, 16, 16, true, "SubMenu1"));

    }
}