using System;
using System.Collections.Generic;
using Systems.Events;
using MainLevel.Data;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Level.Panels.TroopsCreator.Page
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
            TroopsPageParameters troopsPageParameter = _pageParameters[0];
            StartProducingTroop(troopsPageParameter);
        }

        private void PressedButton2()
        {
            TroopsPageParameters troopsPageParameter = _pageParameters[1];
            StartProducingTroop(troopsPageParameter);
        }

        private void PressedButton3()
        {
            TroopsPageParameters troopsPageParameter = _pageParameters[2];
            StartProducingTroop(troopsPageParameter);
        }

        private void StartProducingTroop(TroopsPageParameters troopsPageParameter)
        {
            if (LevelArmy.instance.IsResearched(troopsPageParameter.TroopType))
            {
                int[] prices = new int[3];
                prices[0] = troopsPageParameter.BuyingPriceCrystal;
                prices[1] = troopsPageParameter.BuyingPriceEnergy;
                prices[2] = troopsPageParameter.BuyingPriceFood;
                
                if (LevelResources.instance.IsEnoughResources(prices[0],prices[1],prices[2]))
                {
                    AddToProductionQueue(0);
                    TroopsProducingEvents.ProduceTroop(troopsPageParameter.TroopType);
                    ModifyResources(troopsPageParameter);
                }
            }
            else
            {
                Debug.Log("IsNotResearched!");
            }
        }
        private void AddToProductionQueue(int queueIndex)
        {
            _pageParameters[queueIndex].ProducedTroopsQueue++;
            _productionTroopQueueText[queueIndex].text = _pageParameters[queueIndex].ProducedTroopsQueue.ToString();
        }

        private void ModifyResources(TroopsPageParameters troopsPageParameter)
        {
            ResourcesEventManager.ResourceModify(-troopsPageParameter.BuyingPriceCrystal, ResourceTypes.Crystals);
            ResourcesEventManager.ResourceModify(-troopsPageParameter.BuyingPriceEnergy, ResourceTypes.Energy);
            ResourcesEventManager.ResourceModify(-troopsPageParameter.BuyingPriceFood, ResourceTypes.Food);
        }
        
        
    }
}