using System;
using System.Collections.Generic;
using Systems.Events;
using Level;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Level
{
    [Serializable]
    public class TroopCreatorPage
    {
        [SerializeField] private Button _button1;
        [SerializeField] private Button _button2;
        [SerializeField] private Button _button3;

        [SerializeField] private List<Image> _images;
        [SerializeField] private List<TextMeshProUGUI> _names;
        [SerializeField] private List<TextMeshProUGUI> _pricesCrystals;
        [SerializeField] private List<TextMeshProUGUI> _pricesFood;
        [SerializeField] private List<TextMeshProUGUI> _pricesEnergy;
        [SerializeField] private List<TextMeshProUGUI> _productionTroopQueueText;
        
        private List<TroopsPageParameters> _pageParameters;

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

        public void ConfigurePage( List<TroopsPageParameters> troopsPageParameters)
        {
            _pageParameters = troopsPageParameters;
            for (int i = 0; i < _pageParameters.Count; i++)
            {
                _images[i].sprite = troopsPageParameters[i].Image;
                _names[i].text = troopsPageParameters[i].Name;
                _pricesCrystals[i].text = troopsPageParameters[i].BuyingPriceCrystal.ToString();
                _pricesEnergy[i].text = troopsPageParameters[i].BuyingPriceEnergy.ToString();
                _pricesFood[i].text = troopsPageParameters[i].BuyingPriceFood.ToString();
                _productionTroopQueueText[i].text = _pageParameters[i].ProducedTroopsQueue.ToString();
            }
        }

        private void PressedButton1()
        {
            if (LevelResources.instance.IsEnoughResources(_pageParameters[0].BuyingPriceCrystal,_pageParameters[0].BuyingPriceEnergy, _pageParameters[0].BuyingPriceFood ))
            {
                AddToProductionQueue(0);
                TroopsProducingEvents.ProduceTroop(_pageParameters[0].TroopType);
                LevelEventManager.СrystalsModify(-_pageParameters[0].BuyingPriceCrystal);
                LevelEventManager.EnergyModify(-_pageParameters[0].BuyingPriceEnergy);
                LevelEventManager.FoodModify(-_pageParameters[0].BuyingPriceFood);
            }
        }

        private void PressedButton2()
        {
            if (LevelResources.instance.IsEnoughResources(_pageParameters[1].BuyingPriceCrystal,
                _pageParameters[1].BuyingPriceEnergy, _pageParameters[1].BuyingPriceFood))
            {
                AddToProductionQueue(1);
                TroopsProducingEvents.ProduceTroop(_pageParameters[1].TroopType);
                LevelEventManager.СrystalsModify(-_pageParameters[1].BuyingPriceCrystal);
                LevelEventManager.EnergyModify(-_pageParameters[1].BuyingPriceEnergy);
                LevelEventManager.FoodModify(-_pageParameters[1].BuyingPriceFood);
            }
        }

        private void PressedButton3()
        {
            if (LevelResources.instance.IsEnoughResources(_pageParameters[2].BuyingPriceCrystal,
                _pageParameters[2].BuyingPriceEnergy, _pageParameters[2].BuyingPriceFood))
            {
                AddToProductionQueue(2);
                TroopsProducingEvents.ProduceTroop(_pageParameters[2].TroopType);
                LevelEventManager.СrystalsModify(-_pageParameters[2].BuyingPriceCrystal);
                LevelEventManager.EnergyModify(-_pageParameters[2].BuyingPriceEnergy);
                LevelEventManager.FoodModify(-_pageParameters[2].BuyingPriceFood);
            }
        }

        private void AddToProductionQueue(int queueIndex)
        {
            _pageParameters[queueIndex].ProducedTroopsQueue++;
            _productionTroopQueueText[queueIndex].text = _pageParameters[queueIndex].ProducedTroopsQueue.ToString();
        }
        
        
    }
}