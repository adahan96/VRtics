using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cubeScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(OVRGazePointer.instance.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnVREnter()
    {
 
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
    void OnVRTriggerReleased()
    {
        //    UIController boss = new UIController();
        //    boss.CreateBarChart(new BarChartSpecifications(new Vector3(-350, 0, 0), new Vector2(317, 317), "BarChart78", 38.77f, 33.77f, 16, 16, 16, true, "SubMenu1"));
        
    }
}
