using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public struct UseCaseSpecifications
{
    public string[] useCaseNames;
    public int noOfUseCases;
    public Vector2 size;
    public List<UnityEngine.Events.UnityAction> functionsForUseCases;
    public string parent;

    public UseCaseSpecifications(string parent, string[] useCaseNames, int noOfUseCases, Vector2 size, List<UnityEngine.Events.UnityAction> functionsForUseCases)
    {
        this.parent = parent; // specify the parent menu/canvas of the menu to be created
        this.useCaseNames = useCaseNames; // Give names to your use cases
        this.noOfUseCases = noOfUseCases; // Number of use cases
        this.size = size;   // size of the Menu
        this.functionsForUseCases = functionsForUseCases; // The onClick functions for each button: Eg: "QuitGame();"

    }

}