using ChartAndGraph;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cubeScript : MonoBehaviour
{
    public Vector3 initialPos;
    public Quaternion initialRot;
    public GraphChartSpecifications gcs;
    public LineChart LC;
    public UseCase UC;
    public CanvasData cd;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(OVRGazePointer.instance.transform.position);
        gcs = new GraphChartSpecifications(new Vector3(0, 0, 0), new Vector2(600, 400), "Merih Kapı2 sıcaklık1", 2f, 13, AxisFormat.Time, 1f, 12, 2.569, 11.19, "Canvas_Right", "Canvas_Left_Left");
        cd = FindObjectOfType(typeof(CanvasData)) as CanvasData;
        LC = FindObjectOfType(typeof(LineChart)) as LineChart;
        UC = FindObjectOfType(typeof(UseCase)) as UseCase;
        //    OnVRTriggerReleased();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnVREnter()
    {
        initialPos = this.transform.position;
        initialRot = this.transform.rotation;
    }
    void OnVRExit()
    {

    }
    void OnVRTriggerDown(Vector3 RaycastPosition)
    {

        Debug.Log("TRIGGERED BEING PRESSED!!!");
        //  UIController boss = new UIController();
        //  boss.CreateBarChart(new BarChartSpecifications(new Vector3(350, 0, 0), new Vector2(317, 317), "BarChart78", 38.77f, 33.77f, 16, 16, 16, true, "SubMenu1"));
        this.transform.position = RaycastPosition;
        
      //  this.transform.GetChild(0).transform.parent.position = this.transform.position;
       
    }
    void OnVRTry(Quaternion rotasyon)
    {
        this.transform.rotation = rotasyon;
    }
    void OnVRTriggerReleased()
    {
        this.transform.position = initialPos;
        this.transform.rotation = initialRot;
        gcs = new GraphChartSpecifications(new Vector3(0,0,0), new Vector3(600,400), this.transform.name, 2f, this.GetComponent<VerticalAxis>().GetComponent<Text>().fontSize, this.GetComponent<HorizontalAxis>().Format, 1f, this.GetComponent<HorizontalAxis>().GetComponent<Text>().fontSize, this.GetComponent<StreamingGraph>().lineThickness, this.GetComponent<StreamingGraph>().pointSize, cd.canvasName);
        LC.CreateLineChart(gcs);
        UC.saveLineChartToDashboard(GameObject.Find("DashboardName").GetComponent<Text>().text, gcs);
        //    UIController boss = new UIController();
        //    boss.CreateBarChart(new BarChartSpecifications(new Vector3(-350, 0, 0), new Vector2(317, 317), "BarChart78", 38.77f, 33.77f, 16, 16, 16, true, "SubMenu1"));

    }
}
