using System;
using UnityEngine;

namespace Entities.Structures.Data_and_Enams
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
        [TextArea]
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
            get => _updateCrystalsPrice;
            set => _updateCrystalsPrice = value;
        }

        public string Information
        {
            get => _information;
            set => _information = value;
        }
        
        public bool IsInteractable
        {
            get => _isInteractable;
            set => _isInteractable = value;
        }
        public BuildingTypes BuildingType
        {
            get => _buildingType;
            set => _buildingType = value;
        }
        public BuildingLevels BuildingLevel
        {
            get => _buildingLevel;
            set => _buildingLevel = value;
        }
        public GameObject PlacePosition
        {
            get => _placePosition;
            set => _placePosition = value;
        }
    }
}