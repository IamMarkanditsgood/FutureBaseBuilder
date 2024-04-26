using System;
using UnityEngine;

namespace Enteties.Buildings
{
    [Serializable]
    public class BuildsData
    {
        [SerializeField] private BuildingTypes _buildingType;
        [SerializeField] private BuildingLevels _buildingLevel;
        [SerializeField] private GameObject _placePosition;
        [SerializeField] private bool _isInteractable;
        [SerializeField] private int _updatePrice;
        [TextAreaAttribute]
        [SerializeField] private string _information;

        public string Information
        {
            get { return _information; }
            set { _information = value; }
        }
        public int UpdatePrice 
        {
            get { return _updatePrice; }
            set { _updatePrice = value; }
        }
        public bool IsInteractable
        {
            get { return _isInteractable; }
            set { _isInteractable = value; }
        }
        public BuildingTypes BuildingType
        {
            get { return _buildingType; }
            set { _buildingType = value; }
        }
        public BuildingLevels BuildingLevel
        {
            get { return _buildingLevel; }
            set { _buildingLevel = value; }
        }
        public GameObject PlacePosition
        {
            get { return _placePosition; }
            set { _placePosition = value; }
        }
    }
}