﻿using Entities.Structures.Data_and_Enams;
using UnityEngine;

public class BuyingParameters 
{
    private GameObject _choosedPlatform;
    private GameObject _choosetPosition;
    private BuildingTypes _buildingTypes;

    public GameObject ChoosedPlatform
    {
        get => _choosedPlatform;
        set => _choosedPlatform = value;
    }
    public GameObject ChoosetPosition
    {
        get { return _choosetPosition; }
        set { _choosetPosition = value; }
    }
    public BuildingTypes BuildingTypes
    {
        get { return _buildingTypes; }
        set { _buildingTypes = value; }
    }
    
}