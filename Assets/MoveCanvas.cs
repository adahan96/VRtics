using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCanvas : MonoBehaviour
{

    // Start is called before the first frame update
    GameObject main;
    GameObject left;
    GameObject right;
    GameObject leftleft;

    void Start()
    {
        main = GameObject.Find("Canvas");
        left = GameObject.Find("Canvas_Left");
        right = GameObject.Find("Canvas_Right");
        leftleft = GameObject.Find("Canvas_Left_Left");
        MoveRight();  
    }
    TimeSpan startTimeSpan = TimeSpan.Zero;
    TimeSpan periodTimeSpan = TimeSpan.FromSeconds(5);
    // Update is called once per frame
    int lapse = 0;
    void Update()
    {
        lapse++;
        if (lapse % 360 == 0)
        {
            MoveLeft();
            lapse = 0;
        }
        

      
    }
    public void MoveRight()
    {
        

        Quaternion mainRot = main.transform.rotation;
        Quaternion leftRot = left.transform.rotation;
        Quaternion rightRot = right.transform.rotation;
        Quaternion leftleftRot = leftleft.transform.rotation;

        Vector3 mainPos = main.transform.position;
        Vector3 leftPos = left.transform.position;
        Vector3 rightPos = right.transform.position;
        Vector3 leftleftPos = leftleft.transform.position;

        leftleft.transform.position = leftPos;
        leftleft.transform.rotation = leftRot;

        left.transform.position = mainPos;
        left.transform.rotation = mainRot;

        main.transform.position = rightPos;
        main.transform.rotation = rightRot;

        right.transform.position = leftleftPos;
        right.transform.rotation = leftleftRot;
    }
    public void MoveLeft()
    {


        Quaternion mainRot = main.transform.rotation;
        Quaternion leftRot = left.transform.rotation;
        Quaternion rightRot = right.transform.rotation;
        Quaternion leftleftRot = leftleft.transform.rotation;

        Vector3 mainPos = main.transform.position;
        Vector3 leftPos = left.transform.position;
        Vector3 rightPos = right.transform.position;
        Vector3 leftleftPos = leftleft.transform.position;

        leftleft.transform.position = rightPos;
        leftleft.transform.rotation = rightRot;

        left.transform.position = leftleftPos;
        left.transform.rotation = leftleftRot;

        main.transform.position = leftPos;
        main.transform.rotation = leftRot;

        right.transform.position = mainPos;
        right.transform.rotation = mainRot;
    }
}
