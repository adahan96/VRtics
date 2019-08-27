using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public struct MenuSpecifications
{
    public string menuName;
    public string[] buttonNames;
    public int noOfButtons;
    public Vector2 size;
    public List<UnityEngine.Events.UnityAction> functionsForButtons;
    public string parent;
    public string canvas;
    public Vector3 menuPosition;

    public MenuSpecifications(string canvas, string parent, string menuName, string[] buttonNames, int noOfButtons, Vector2 size, List<UnityEngine.Events.UnityAction> functionsForButtons, Vector3 menuPosition)
    {
        this.canvas = canvas;
        this.parent = parent; // specify the parent menu/canvas of the menu to be created
        this.menuName = menuName; // Give a name to your menu
        this.buttonNames = buttonNames; // Give names to your buttons
        this.noOfButtons = noOfButtons; // Number of buttons
        this.size = size;   // size of the Menu
        this.functionsForButtons = functionsForButtons; // The onClick functions for each button: Eg: "QuitGame();"
        this.menuPosition = menuPosition; // Position with respect to the parent 
    }
    public MenuSpecifications(string canvas, string menuName, string[] buttonNames, int noOfButtons, Vector2 size, List<UnityEngine.Events.UnityAction> functionsForButtons, Vector3 menuPosition)
    {
        this.canvas = canvas;
        parent = null; // specify the parent menu/canvas of the menu to be created
        this.menuName = menuName; // Give a name to your menu
        this.buttonNames = buttonNames; // Give names to your buttons
        this.noOfButtons = noOfButtons; // Number of buttons
        this.size = size;   // size of the Menu
        this.functionsForButtons = functionsForButtons; // The onClick functions for each button: Eg: "QuitGame();"
        this.menuPosition = menuPosition; // Position with respect to the parent 
    }
}