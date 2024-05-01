using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace Enteties.Buildings
{
    [Serializable]
    public class BuildsData
    {
        [SerializeField] private BuildingTypes _buildingType;
        [SerializeField] private BuildingLevels _buildingLevel;
        [SerializeField] private GameObject _placePosition;
        [SerializeField] private bool _isInteractable;
        [SerializeField] private int _updateCrystalsPrice;
        [SerializeField] private int _updateFoodPrice;
        [SerializeField] private int _updateEnergyPrice;
        [TextAreaAttribute]
        [SerializeField] private string _information;
        public int UpdateFoodPrice
        {
            get => _updateFoodPrice;
            set => _updateFoodPrice = value;
        }

        public int UpdateEnergyPrice
        {
            get => _updateEnergyPrice;
            set => _updateEnergyPrice = value;
        }
        public int UpdateCrystalsPrice 
        {
            get { return _updateCrystalsPrice; }
            set { _updateCrystalsPrice = value; }
        }

        public string Information
        {
            get { return _information; }
            set { _information = value; }
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