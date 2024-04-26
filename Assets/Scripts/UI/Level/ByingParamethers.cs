using Enteties.Buildings;
using UnityEngine;

public class ByingParamethers 
{
    private GameObject _choosedPlatform;
    private GameObject _choosetPosition;
    private BuildingTypes _buildingTypes;

    public GameObject ChoosedPlatform
    {
        get { return _choosedPlatform; }
        set { _choosedPlatform = value; }
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