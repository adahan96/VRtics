using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonInfo : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
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
}
