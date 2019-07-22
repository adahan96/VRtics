#define Graph_And_Chart_PRO
using UnityEngine;
using System.Collections;
using ChartAndGraph;
using System;

public class StreamingGraph : MonoBehaviour
{
    public GraphChart Graph;
    public int TotalPoints = 5;
    float lastTime = 0f;
    float lastX = 0f;
    public static string category = "sa";
    
    public double lineThickness = 2.56;
    public MaterialTiling lineTiling = new MaterialTiling(false, 1f);
    public Material innerFill;
    public static bool strechFill = false;
    public Material pointMaterial;
    public Material lineMaterial;
    public double pointSize = 11.3;

 
    void Start()
    {
        
        Debug.Log("UPDATE UPDATE UPDATE");
        Graph = GetComponent<GraphChart>();
        Graph.DataSource.AddCategory("sa", lineMaterial, lineThickness, lineTiling, innerFill, strechFill, pointMaterial, pointSize);
        if (Graph == null) // the ChartGraph info is obtained via the inspector
            return;
        float x = 3f * TotalPoints;
        Graph.DataSource.StartBatch(); // calling StartBatch allows changing the graph data without redrawing the graph for every change
        Graph.DataSource.ClearCategory("Player 1"); // clear the "Player 1" category. this category is defined using the GraphChart inspector
    //    Graph.DataSource.ClearCategory("P2"); // clear the "Player 2" category. this category is defined using the GraphChart inspector

        for (int i = 0; i < TotalPoints; i++)  //add random points to the graph
        {
            Graph.DataSource.AddPointToCategory("sa", System.DateTime.Now - System.TimeSpan.FromSeconds(x), UnityEngine.Random.value * 20f + 10f); // each time we call AddPointToCategory 
            Debug.Log("???");
           Graph.DataSource.AddPointToCategory("Player 1", System.DateTime.Now  - System.TimeSpan.FromSeconds(x), UnityEngine.Random.value * 10f); // each time we call AddPointToCategory 
            x -= UnityEngine.Random.value * 3f;
            lastX = x;
        }
        
        GetComponent<GraphChart>().DataSource.HorizontalViewOrigin = (DateTime.Today - new DateTime(1970, 1, 1)).TotalSeconds + (DateTime.Now - DateTime.Today).TotalSeconds;

        Graph.DataSource.EndBatch(); // finally we call EndBatch , this will cause the GraphChart to redraw itself
       

    }

    void Update()
    {
        

        float time = Time.time;
        if (lastTime + 2f < time)
        {
            lastTime = time;
            lastX += UnityEngine.Random.value * 3f;
           
//            System.DateTime t = ChartDateUtility.ValueToDate(lastX);
           Graph.DataSource.AddPointToCategoryRealtime("sa", System.DateTime.Now, UnityEngine.Random.value * 50f + 10f, 2f); // each time we call AddPointToCategory 
            Graph.DataSource.AddPointToCategoryRealtime("Player 1", System.DateTime.Now, UnityEngine.Random.value * 50f + 10f, 2f); // each time we call AddPointToCategory 
           // Graph.DataSource.AddPointToCategoryRealtime("P2", System.DateTime.Now, UnityEngine.Random.value * 10f, 2f); // each time we call AddPointToCategory
          // GetComponent<HorizontalAxis>().
        }

    }
}
