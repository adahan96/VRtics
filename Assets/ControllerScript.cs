using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;

public class ControllerScript : MonoBehaviour
{
    Vector3 dir;
    public Camera mainCamera;
    public GameObject gazePointer;

    [DllImport("user32.dll")]
    static extern bool SetCursorPos(int X, int Y);

    int xPos, yPos;
    public GameObject go;
    // Start is called before the first frame update
    void Start()
    {

    }
    
    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(transform.position, transform.forward * 20, Color.blue);

        if (OVRInput.IsControllerConnected(OVRInput.Controller.RTrackedRemote))
        {
            //transform.position = OVRInput.GetLocalControllerPosition(OVRInput.Controller.RTrackedRemote);
            transform.rotation = OVRInput.GetLocalControllerRotation(OVRInput.Controller.RTrackedRemote);
        }

      /*  RaycastHit hit;
        
        transform.rotation = OVRInput.GetLocalControllerRotation(OVRInput.Controller.RTrackedRemote);
       
        if(Physics.Raycast(transform.position,transform.forward, out hit))
        {
            if(go != hit.collider.gameObject)
            {
                go.SendMessage("OnVRExit");
                go = hit.transform.gameObject;
                go.SendMessage("OnVREnter");
            }
            if(OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger))
            {
                go.transform.SendMessage("OnVRTriggerDown");
            }
        }
        else
        {
            if(go != null)
            {
                go.transform.SendMessage("OnVRExit");
                go = new GameObject();
            }
        }
*/
     //   Debug.Log(hit.collider.gameObject.name);

    }
}
