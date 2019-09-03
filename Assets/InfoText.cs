using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfoText : MonoBehaviour
{
    Dictionary<string, bool> Toggle;
    public GameObject infoText;
    public GameObject InfoTextPrefab;
    Dictionary<string, GameObject> onScreen;
    // Start is called before the first frame update
    void Start()
    {
        Toggle = new Dictionary<string, bool>();
        onScreen = new Dictionary<string, GameObject>();
        //   DashboardElementBackground = new GameObject();
    //    InfoTextSpecifications its = new InfoTextSpecifications("Canvas_Right", "Canvas_Right", "Merih", "HUB 1", "Lorem ipsum dolor sit", new Vector2(149f, 149f), new Vector3(0, 0, 0));
      //  CreateInfoText(its);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void CreateInfoText(InfoTextSpecifications its)
    {
        if (its.parent != null)
        {
            /*
            if (!Toggle.ContainsKey(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name))
            {
               string pressedButtonName = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name;
               Toggle[pressedButtonName] = false;
            }
            if (!Toggle[UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name])
            {
            */
            var panel = GameObject.Find(its.canvas);
            var panel2 = GameObject.Find(its.parent + "Background");
          
            infoText = (GameObject)Instantiate(InfoTextPrefab);
            RectTransform rt = infoText.GetComponent<RectTransform>();
            rt.sizeDelta = its.size;
            infoText.name = its.name;

            infoText.GetComponent<RectTransform>().SetParent(panel.transform);
            if (panel2.transform.parent != panel.transform)
                infoText.transform.localPosition = its.position;
            else
            {
                infoText.transform.localPosition = its.position + panel2.transform.localPosition;
            }

                
                
            infoText.name = its.name;
            infoText.transform.rotation = panel.transform.rotation;

            infoText.transform.GetChild(0).GetComponent<Text>().text = its.body;
            RectTransform rt_body = infoText.transform.GetChild(0).GetComponent<RectTransform>();
            rt_body.sizeDelta = its.size * new Vector2(0.8f, 0.8f);
            infoText.transform.GetChild(1).GetComponent<Text>().text = its.head;
            infoText.transform.GetChild(1).transform.localPosition = new Vector3(0, its.size.y / 1.7f, 0);
            RectTransform rt_head = infoText.transform.GetChild(1).GetComponent<RectTransform>();
            rt_head.sizeDelta = its.size * new Vector2(1f, 0.2f);

            onScreen[its.name] = infoText;
          //  Toggle[UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name] = true;
            /*
            }

            else
            {
            //Destroy the object
                Destroy(onScreen[its.name]);
            //Remove the destroyed objects from the Onscreen dictionary
                onScreen.Remove(its.name);
            //Set the buttons state to false indicating that it is not pressed yet
                Toggle[UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name] = false;
            }
            */
        }
        else
        {
            var panel = GameObject.Find(its.canvas);

            infoText = (GameObject)Instantiate(InfoTextPrefab);
            RectTransform rt = infoText.GetComponent<RectTransform>();
            rt.sizeDelta = its.size;
            infoText.name = its.name;

            infoText.GetComponent<RectTransform>().SetParent(panel.transform);
            infoText.transform.localPosition = its.position;
            infoText.transform.rotation = panel.transform.rotation;
            infoText.name = its.name;

            infoText.transform.GetChild(0).GetComponent<Text>().text = its.body;
            RectTransform rt_body = infoText.transform.GetChild(0).GetComponent<RectTransform>();
            rt_body.sizeDelta = its.size * new Vector2(0.8f,0.8f);
            infoText.transform.GetChild(1).GetComponent<Text>().text = its.head;
            infoText.transform.GetChild(1).transform.localPosition = new Vector3(0, its.size.y / 1.7f, 0);
            RectTransform rt_head = infoText.transform.GetChild(1).GetComponent<RectTransform>();
            rt_head.sizeDelta = its.size * new Vector2(1f, 0.2f);


        }
    }
}
