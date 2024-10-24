using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public string listOfNames;
    public string listOfCosts;
    public string listofQuantities;

    public GameData() 
    {
        this.listOfNames = "";
        this.listOfCosts = "";
        this.listofQuantities = "";
    }
}
