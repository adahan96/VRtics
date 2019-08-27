using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public struct InfoTextSpecifications
{
    public string name;
    public Vector2 size;
    public Vector3 position;
    public string parent;
    public string canvas;
    public string head;
    public string body;

    public InfoTextSpecifications(string parent, string canvas, string name, string head, string body, Vector2 size, Vector3 position)
    {
        this.parent = parent; // specify the parent menu/canvas of the menu to be created
        this.name = name;
        this.head = head;
        this.body = body;
        this.size = size;   // size of the Menu
        this.canvas = canvas;
        this.position = position;
    }
    public InfoTextSpecifications(string canvas, string name, string head, string body, Vector2 size, Vector3 position)
    {
        parent = null; // specify the parent menu/canvas of the menu to be created
        this.name = name;
        this.head = head;
        this.body = body;
        this.size = size;   // size of the Menu
        this.canvas = canvas;
        this.position = position;
    }

}