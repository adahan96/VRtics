﻿using ChartAndGraph;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UseCase : MonoBehaviour
{
    public GameObject[] useCases;
    public GameObject useCasePrefab;
    public UseCaseSpecifications ucs;
    List<UnityEngine.Events.UnityAction> ffuc = new List<UnityEngine.Events.UnityAction>();

    public BarChartClass BC;
    public LineChart LC;
    public GraphChartSpecifications gcs;
    public GraphChartSpecifications gcs1;
    public GraphChartSpecifications gcs2;
    public GraphChartSpecifications gcs3;
    public BarChartSpecifications bcs;
    public void fillDummyVar()
    {
        ffuc.Add(() => { ClearCanvas(gcs.Canvas); LC.CreateLineChart(gcs);  });
        ffuc.Add(() => { ClearCanvas(gcs1.Canvas); LC.CreateLineChart(gcs1); });
        ffuc.Add(() => { ClearCanvas(gcs2.Canvas); LC.CreateLineChart(gcs2); });
        ffuc.Add(() => { ClearCanvas(gcs3.Canvas); LC.CreateLineChart(gcs3); });
    }

    // Start is called before the first frame update
    void Start()
    {
        BC = FindObjectOfType(typeof(BarChartClass)) as BarChartClass;
        LC = FindObjectOfType(typeof(LineChart)) as LineChart;
        bcs = new BarChartSpecifications(new Vector3(-350, 0, 0), new Vector2(317, 317), "BarChart77", 48.77f, 23.77f, 13, 13, 13, true, "Canvas_Left", "Canvas_Left");
        gcs = new GraphChartSpecifications(new Vector3(0, 0, 0), new Vector2(600, 400), "Merih Kapı 1", 2f, 13, AxisFormat.Time, 1f, 12, 2.569, 11.19, "Canvas_Left", "Canvas_Left");
        gcs1 = new GraphChartSpecifications(new Vector3(0, 0, 0), new Vector2(600, 400), "Merih puch 1", 2f, 13, AxisFormat.Time, 1f, 12, 2.569, 11.19, "Canvas_Left", "Canvas_Left");
        gcs2 = new GraphChartSpecifications(new Vector3(0, 0, 0), new Vector2(600, 400), "Merih Kapı 2", 2f, 13, AxisFormat.Time, 1f, 12, 2.569, 11.19, "Canvas_Left", "Canvas_Left");
        gcs3 = new GraphChartSpecifications(new Vector3(0, 0, 0), new Vector2(600, 400), "Antalya Demir", 2f, 13, AxisFormat.Time, 1f, 12, 2.569, 11.19, "Canvas_Left", "Canvas_Left");
        fillDummyVar();
        ucs = new UseCaseSpecifications("Canvas", new string[] { "Merih kapı1", "Merih punch1", "Merih kapı2", "Antalya_demir" }, 4, new Vector2(100, 100), ffuc);
        addButtonsToMenu(ucs);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void addButtonsToMenu(UseCaseSpecifications ucs)
    {
        useCases = new GameObject[ucs.noOfUseCases];
        for (int i = 0; i < ucs.useCaseNames.Length; i += 1)
        {
            useCases[i] = (GameObject)Instantiate(useCasePrefab);
            // Instantiate (clone) the prefab    

            var panel = GameObject.Find(ucs.parent);
            useCases[i].name = ucs.useCaseNames[i];
            GameObject.Find(ucs.useCaseNames[i]).GetComponentInChildren<Text>().text = ucs.useCaseNames[i];
            useCases[i].transform.position = panel.transform.position;
            //buttons[i].transform.SetPositionAndRotation(panel.transform.position + m.menuPosition, new Quaternion(0,0,0,0));
            // buttons[i].transform.rotation = panel.transform.rotation;
            useCases[i].GetComponent<RectTransform>().SetParent(panel.transform);
            RectTransform rt = useCases[i].GetComponent<RectTransform>();
            rt.sizeDelta = ucs.size;
            if (ucs.functionsForUseCases != null)
            {
                useCases[i].GetComponent<Button>().onClick.AddListener(ucs.functionsForUseCases[i]);
            }
            useCases[i].transform.rotation = panel.transform.rotation;
        }
    }
    private void ClearCanvas(string canvasName)
    {
        GameObject canvas = GameObject.Find(canvasName);
        foreach (Transform child in canvas.transform)
        {
            Destroy(child.gameObject);
        }
    }
}
