using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRticsInitializer : MonoBehaviour
{
    //<summary> This script is called before any script to initialize canvases. 
    //Each UI element will reside on these canvases. 
    //The number, size, position and material of canvases can be determined via a JSON file.
    //The name of the canvases are predetermined. 
    //The canvas that is at the center and in front of the use is called "Canvas".
    //The left and right canvases are named "Canvas_left", "Canvas_right" respectively.
    //The top and the bottom canvases are named "Canvas_top", "Canvas_bottom"
    //The back canvas is named "Canvas_back"
    //The user determines the sizes of canvases. 
    //The sizes should be given respectively as main, left, right, top, bottom, back. The size should be 0 if the user does not want that canvas active. 
    //</summary>
    CanvasSpecifications cs;
    // DUMMY DATA -> Represents JSON data. TO BE DELETED. 
    
    public GameObject[] Canvases = new GameObject[6];
    public static Vector2[] dummySize = {new Vector2(200,200), new Vector2(400, 200), new Vector2(400, 200), new Vector2(200, 400), new Vector2(200, 400), new Vector2(200, 200) };
    public static Vector3 dummyPos = new Vector3(2000, 2000, 550);
    public GameObject CanvasPrefab;

    // DUMMY DATA -> Represents JSON data. TO BE DELETED.
    private void Awake()
    {
        Vector3[] Rotations = {new Vector3(0,0,0), new Vector3(0, 90, 0), new Vector3(0, 90, 0), new Vector3(90, 0, 0), new Vector3(90, 0, 0), new Vector3(0, 0, 0)};
        Debug.Log("hello???????????");
        cs = new CanvasSpecifications(dummySize, dummyPos);
        Vector3[] RelativePositions  = new Vector3[6];
        RelativePositions[0] = dummyPos;
        RelativePositions[1] = dummyPos + new Vector3((-dummySize[0].x /2), 0, (-dummySize[1].x/2));
        RelativePositions[2] = dummyPos + new Vector3((dummySize[0].x / 2), 0, (-dummySize[1].x / 2));
        RelativePositions[3] = dummyPos + new Vector3(0, (-dummySize[0].y / 2), (-dummySize[1].x / 2));
        RelativePositions[4] = dummyPos + new Vector3(0, (dummySize[0].y / 2), (-dummySize[1].x / 2));
        RelativePositions[5] = dummyPos + new Vector3(0, 0, -Mathf.Max(dummySize[3].y, dummySize[4].y));

        for (int i = 0; i < dummySize.Length; i++)
        {          
            Canvases[i] = (GameObject)Instantiate(CanvasPrefab);   
            Canvases[i].name = "Canvas2" + i.ToString();
            Debug.Log("hello???????????");
            Canvases[i].GetComponent<RectTransform>().sizeDelta = dummySize[i];
            Canvases[i].GetComponent<RectTransform>().position = RelativePositions[i];
            Canvases[i].GetComponent<RectTransform>().Rotate(Rotations[i]);
        }
        Debug.Log("UTANAPISTI");
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
