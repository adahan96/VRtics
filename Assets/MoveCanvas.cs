using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCanvas : MonoBehaviour
{

    public Vector3[] positions;
    public Vector3[] rotations;

    // Start is called before the first frame update
    GameObject main;
    GameObject left;
    GameObject right;
    GameObject leftleft;
    bool TriggerMoveRight = false;
    bool moveRight = false;
    bool movementComplete = true;
    bool mutex = true;
    Vector3 mainRot;
    Vector3 leftRot;
    Vector3 rightRot;
    Vector3 leftleftRot;

    Vector3 mainPos;
    Vector3 leftPos;
    Vector3 rightPos;
    Vector3 leftleftPos;

    int mainIndex;
    int leftIndex;
    int rightIndex;
    int leftleftIndex;

    Vector3 dif0;
    Vector3 dif1;
    Vector3 dif2;
    Vector3 dif3;
    Quaternion rot0;
    Vector3 angleDif0; Vector3 angleDif1; Vector3 angleDif2; Vector3 angleDif3;
    void Start()
    {
        mainIndex = 0; rightIndex = 1; leftIndex = 7; leftleftIndex = 6;
        positions = new Vector3[] { new Vector3(0,0,650), new Vector3(683, 0, 346), new Vector3(937, 0, -384), new Vector3(649, 0, -1168), new Vector3(-52, 0, -1497), new Vector3(-794, 0, -1167), new Vector3(-945, 0, -390), new Vector3(-683, 0, 347) };
        rotations = new Vector3[] { new Vector3(0, -360, 0), new Vector3(0, -310 , 0), new Vector3(0, -270, 0), new Vector3(0, -230, 0), new Vector3(0, -180, 0), new Vector3(0, -130, 0), new Vector3(0, -90, 0), new Vector3(0, -50, 0) };
        main = GameObject.Find("Canvas");
        left = GameObject.Find("Canvas_Left");
        right = GameObject.Find("Canvas_Right");
        leftleft = GameObject.Find("Canvas_Left_Left");
        //MoveRight();
       // for(int i = 0; i < 2; i++)
         //   InitiateMovementRight();
    }
    TimeSpan startTimeSpan = TimeSpan.Zero;
    TimeSpan periodTimeSpan = TimeSpan.FromSeconds(5);
    // Update is called once per frame
    int lapse = 0;
    void Update()
    {
        
        MoveRight();

        //  lapse++;
      //    if (lapse % 360 == 0)
      //   {
          //   InitiateMovementRight();
        //     lapse = 0;
        // }
        



    }
    public void MoveRight()
    {
        if(TriggerMoveRight)
        {
            mainRot = rotations[mainIndex%8];
            leftRot = rotations[leftIndex % 8];
            rightRot = rotations[rightIndex % 8];
            leftleftRot = rotations[leftleftIndex % 8];

            mainPos = positions[mainIndex % 8];
            leftPos = positions[leftIndex % 8];
            rightPos = positions[rightIndex % 8];
            leftleftPos = positions[leftleftIndex % 8];

            dif0 = (positions[(leftleftIndex + 1) % 8] - positions[(leftleftIndex) % 8]) / 200f;
            dif1 = (positions[(leftIndex + 1) % 8] - positions[(leftIndex) % 8]) / 200f;
            dif2 = (positions[(mainIndex + 1) % 8] - positions[(mainIndex) % 8]) / 200f;
            dif3 = (positions[(rightIndex + 1) % 8] - positions[(rightIndex) % 8]) / 200f;

            //rot0 = new Vector3(0, (leftRot.y - leftleft.transform.rotation.y) / 500f, 0);
            angleDif0 = (rotations[(leftleftIndex + 1) % 8] - rotations[(leftleftIndex) % 8]) / 200f;
            angleDif1 = (rotations[(leftIndex + 1) % 8] - rotations[(leftIndex) % 8]) / 200f;
            angleDif2 = (rotations[(mainIndex + 1) % 8] - rotations[(mainIndex) % 8]) / 200f;
            angleDif3 = (rotations[(rightIndex + 1) % 8] - rotations[(rightIndex) % 8]) / 200f;


            Debug.Log(angleDif3);
            // Debug.Log(rot0);
            // Debug.Log(leftRot.eulerAngles);
            //int checkIndex = mainIndex;
            mainIndex++;
            leftIndex++;
            rightIndex++;
            leftleftIndex++;

        }
        if (moveRight)
        {
            TriggerMoveRight = false;
            leftleft.transform.position += dif0;
            left.transform.position += dif1;
            main.transform.position += dif2;
            right.transform.position += dif3;
            //leftleft.transform.Rotate();
            //leftleft.transform.rotation *= rot0;
            leftleft.transform.Rotate(angleDif0);
            left.transform.Rotate(angleDif1);
            main.transform.Rotate(angleDif2);
            right.transform.Rotate(angleDif3);
            if (Vector3.Distance(leftleft.transform.position, leftPos) < 1.0f)
            {
                moveRight = false;
                Debug.Log("GIRIYON MU");
                mutex = true;
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
    public void InitiateMovementRight()
    {
        if (mutex)
        {
            moveRight = true;
            TriggerMoveRight = true;
        }
        mutex = false;
    }
}

