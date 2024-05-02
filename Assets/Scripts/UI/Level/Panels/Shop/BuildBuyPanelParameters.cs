using System;
using Entities.Structures.Data_and_Enams;
using UnityEngine;

namespace UI.Level.Panels.Shop
{
    [Serializable]
    public struct BuildBuyPanelParameters
    {
        [SerializeField] private BuildingTypes _buildingType;
        [SerializeField] private String _name;
        [SerializeField] private Sprite _image;
        [SerializeField] private int _buyingPriceCrystal;
        [SerializeField] private int _buyingPriceFood;
        [SerializeField] private int _buyingPriceEnergy;
        
        public BuildingTypes BuildingTypes
        {
            get => _buildingType;
            set => _buildingType = value;
        }
        
        public string Name
        {
            get => _name;
            set => _name = value;
        }

        public Sprite Image
        {
            get => _image;
            set => _image = value;
        }

        public int BuyingPriceCrystal
        {
            get => _buyingPriceCrystal;
            set => _buyingPriceCrystal = value;
        }

        public int BuyingPriceFood
        {
            get => _buyingPriceFood;
            set => _buyingPriceFood = value;
        }

        public int BuyingPriceEnergy
        {
            get => _buyingPriceEnergy;
            set => _buyingPriceEnergy = value;
        }

        
    }
}