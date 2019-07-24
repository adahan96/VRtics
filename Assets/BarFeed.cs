#define Graph_And_Chart_PRO
using UnityEngine;
using System.Collections;
using ChartAndGraph;

public class BarFeed : MonoBehaviour
{
    public string[] categories { get; set; }
    public string group { get; set; }
    public float[] values { get; set; }


    // REPRESENTS JSON DATA. TO BE DELETED.

    static string[] cgs = { "sensor1", "sensor2", "sensor3" };
    static string grp = "Group 1";
    static float[] vls = { 14.4f, 8f, 2f };
    public Material barMaterial;

    // REPRESENTS JSON DATA. TO BE DELETED.


    public BarFeed()
    {
        categories = cgs;
        group = grp;
        values = vls;
    }


    // Start is called before the first frame update
    
    void Start()
    {
        BarChart barChart = GetComponent<BarChart>();
        if (barChart != null)
        {
            for (int i = 0; i < categories.Length; i++)
            {
                Material pointMaterial = Resources.Load(string.Format("Materials/_pointaaa0"), typeof(Material)) as Material;
                Debug.Log(pointMaterial);
                Debug.Log("HERE");
                ChartDynamicMaterial CDM = new ChartDynamicMaterial(barMaterial);

                barChart.DataSource.AddCategory(categories[i], CDM);
                barChart.DataSource.SetValue(categories[i], "All", values[i]);
            }
            barChart.GetComponent<BarAnimation>().Animate();
        }
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}