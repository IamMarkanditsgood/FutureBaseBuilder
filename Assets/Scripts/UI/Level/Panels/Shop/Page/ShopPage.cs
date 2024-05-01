using System;
using System.Collections.Generic;
using Systems.Events;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace UI.Level
{
    [Serializable]
    public class ShopPage
    {
         [SerializeField] private Button _button1;
         [SerializeField] private Button _button2;
         [SerializeField] private Button _button3;

         [SerializeField] private List<Image> _images;
         [SerializeField] private List<TextMeshProUGUI> _names;
         [SerializeField] private List<TextMeshProUGUI> _pricesCrystals;
         [SerializeField] private List<TextMeshProUGUI> _pricesFood;
         [SerializeField] private List<TextMeshProUGUI> _pricesEnergy;
        
        private BuyingParameters _buyingParameters = new BuyingParameters();
        private List<BuildBuyPanelParameters> _pageParameters;
        private GameObject _shopPanel;
        

        public void Subscribe()
        {
            _button1.onClick.AddListener(PressedButton1);
            _button2.onClick.AddListener(PressedButton2);
            _button3.onClick.AddListener(PressedButton3);
        }
        
        public void Unsubscribe()
        {
            _button1.onClick.RemoveListener(PressedButton1);
            _button2.onClick.RemoveListener(PressedButton2);
            _button3.onClick.RemoveListener(PressedButton3);
              
        }
        
        public void ConfigureBuyingParameters(BuyingParameters buyingParameters, List<BuildBuyPanelParameters> pageParameters, GameObject shopPanel)
        {
            _shopPanel = shopPanel;
            _buyingParameters = buyingParameters;
            _pageParameters = pageParameters;
            CreateStructureBuyPanel();
        }

        private void CreateStructureBuyPanel()
        {
            for (int i = 0; i < _pageParameters.Count; i++)
            {
                _names[i].text = _pageParameters[i].Name;
                _pricesCrystals[i].text = _pageParameters[i].BuyingPriceCrystal.ToString();
                _pricesFood[i].text = _pageParameters[i].BuyingPriceFood.ToString();
                _pricesEnergy[i].text = _pageParameters[i].BuyingPriceEnergy.ToString();
                _images[i].sprite = _pageParameters[i].Image;
            }
        }
        private void PressedButton1()
        {
            int numberOfButton = 0;
            ConfigureBuyingParameters(numberOfButton);
            LevelEventManager.CreatePurchasedBuild(_buyingParameters);
            _shopPanel.SetActive(false);
            LevelEventManager.CloseUI();
        }
        private void PressedButton2()
        {
            int numberOfButton = 1;
            ConfigureBuyingParameters(numberOfButton);
            LevelEventManager.CreatePurchasedBuild(_buyingParameters);
            _shopPanel.SetActive(false);
            LevelEventManager.CloseUI();
        }
        private void PressedButton3()
        {
            int numberOfButton = 2;
            ConfigureBuyingParameters(numberOfButton);
            LevelEventManager.CreatePurchasedBuild(_buyingParameters);
            _shopPanel.SetActive(false);
            LevelEventManager.CloseUI();
        }

        private void ConfigureBuyingParameters(int numberOfButton)
        {
            _buyingParameters.BuildingTypes = _pageParameters[numberOfButton].BuildingTypes;
            LevelEventManager.EnergyModify(-_pageParameters[numberOfButton].BuyingPriceEnergy); 
            LevelEventManager.FoodModify(-_pageParameters[numberOfButton].BuyingPriceFood);
            LevelEventManager.СrystalsModify(-_pageParameters[numberOfButton].BuyingPriceCrystal);
        }
    }
}