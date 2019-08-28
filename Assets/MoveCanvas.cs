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
    bool TriggerMove = true;
    bool move = true;
    Quaternion mainRot;
    Quaternion leftRot;
    Quaternion rightRot;
    Quaternion leftleftRot;

    Vector3 mainPos;
    Vector3 leftPos;
    Vector3 rightPos;
    Vector3 leftleftPos;

    Vector3 dif0;
    Vector3 dif1;
    Vector3 dif2;
    Vector3 dif3;
    Quaternion rot0;
    Vector3 angleDif0; Vector3 angleDif1; Vector3 angleDif2; Vector3 angleDif3;
    void Start()
    {
        main = GameObject.Find("Canvas");
        left = GameObject.Find("Canvas_Left");
        right = GameObject.Find("Canvas_Right");
        leftleft = GameObject.Find("Canvas_Left_Left");
        //MoveRight();  
    }
    TimeSpan startTimeSpan = TimeSpan.Zero;
    TimeSpan periodTimeSpan = TimeSpan.FromSeconds(5);
    // Update is called once per frame
    int lapse = 0;
    void Update()
    {
        //  lapse++;
        //  if (lapse % 360 == 0)
        //  {
        //     MoveLeft();
        //     lapse = 0;
        // }
        //if()
        MoveRight();
        

      
    }
    public void MoveRight()
    {
        if(TriggerMove)
        {
            mainRot = main.transform.rotation;
            leftRot = left.transform.rotation;
            rightRot = right.transform.rotation;
            leftleftRot = leftleft.transform.rotation;

            mainPos = main.transform.position;
            leftPos = left.transform.position;
            rightPos = right.transform.position;
            leftleftPos = leftleft.transform.position;

            dif0 = leftPos - leftleft.transform.position;
            dif1 = mainPos - left.transform.position;
            dif2 = rightPos - main.transform.position;
            dif3 = leftleftPos - right.transform.position;
            //rot0 = new Vector3(0, (leftRot.y - leftleft.transform.rotation.y) / 500f, 0);
            angleDif0 = (leftRot.eulerAngles - leftleftRot.eulerAngles) / 200f;
            angleDif1 = (mainRot.eulerAngles - leftRot.eulerAngles) / 200f;
            Debug.Log(angleDif1);
            angleDif2 = (rightRot.eulerAngles - mainRot.eulerAngles) / 200f;
            angleDif3 = (leftleftRot.eulerAngles - rightRot.eulerAngles) / 200f;

            // Debug.Log(rot0);
            // Debug.Log(leftRot.eulerAngles);

        }
        if (move)
        {
            TriggerMove = false;
            leftleft.transform.position += dif0 / 200f;
            left.transform.position += dif1 / 200f;
            main.transform.position += dif2 / 200f;
            right.transform.position += dif3 / 200f;
            //leftleft.transform.Rotate();
            //leftleft.transform.rotation *= rot0;
            leftleft.transform.Rotate(angleDif0);
            left.transform.Rotate(angleDif1);
            main.transform.Rotate(angleDif2);
            right.transform.Rotate(angleDif3);
            if (Vector3.Distance(leftleft.transform.position, leftPos) < 1.0f)
            {
                move = false;
            }
        }
        //   leftleft.transform.rotation *= rot0;

        //  left.transform.position = mainPos;
        //  left.transform.rotation = mainRot;

        //        main.transform.position = rightPos;
        // main.transform.rotation = rightRot;

        //  right.transform.position = leftleftPos;
        // right.transform.rotation = leftleftRot;
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
