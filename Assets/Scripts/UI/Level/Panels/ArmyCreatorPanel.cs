using System;
using System.Collections;
using System.Collections.Generic;
using Systems.Events;
using TMPro;
using UI.Level;
using UnityEngine;
using UnityEngine.UI;

public class ArmyCreatorPanel : BasicPanelManager
{
    [Serializable]
    private struct Page
    {
        public List<TroopsPageParameters> troopsPageParameterses;
    }

    [SerializeField] private ArmyCreatorPage _armyCreatorPage;
    [SerializeField] private List<Page> _pages;
    [SerializeField] private Button _nextPageButton;
    [SerializeField] private Button _prevPageButton;
    [SerializeField] private TextMeshProUGUI _pageText;

    private int _currentPage;

    private void Start()
    {
        Subscribe();
        _currentPage = 0;
        int textPageNumber = _currentPage + 1;
        _pageText.text = textPageNumber.ToString();
        _armyCreatorPage.ConfigurePage(_pages[_currentPage].troopsPageParameterses);
    }

    private void OnDestroy()
    {
        Unsubscribe();
    }

    private void Subscribe()
    {
        _nextPageButton.onClick.AddListener(NextPage);
        _prevPageButton.onClick.AddListener(PrevPage);
        _armyCreatorPage.Subscribe();
    }

    private void Unsubscribe()
    {
        _nextPageButton.onClick.AddListener(NextPage);
        _prevPageButton.onClick.AddListener(PrevPage);
        _armyCreatorPage.Unsubscribe();
    }

    private void NextPage()
    {
        if (_currentPage == _pages.Count - 1)
        {
            _currentPage = 0;
        }
        else
        {
            _currentPage++;
        }

        int textPage = _currentPage + 1;
        _pageText.text = textPage.ToString();
        _armyCreatorPage.ConfigurePage(_pages[_currentPage].troopsPageParameterses);
    }

    private void PrevPage()
    {
        if (_currentPage == 0)
        {
            _currentPage = _pages.Count - 1;
        }
        else
        {
            _currentPage--;
        }

        int textPage = _currentPage + 1;
        _pageText.text = textPage.ToString();
        _armyCreatorPage.ConfigurePage(_pages[_currentPage].troopsPageParameterses);
    }

    [Serializable]
    public class ArmyCreatorPage
    {
        [SerializeField] private Button _button1;
        [SerializeField] private Button _button2;
        [SerializeField] private Button _button3;

        [SerializeField] private List<Image> _images;
        [SerializeField] private List<TextMeshProUGUI> _names;
        [SerializeField] private List<TextMeshProUGUI> _pricesCrystals;
        [SerializeField] private List<TextMeshProUGUI> _pricesFood;
        [SerializeField] private List<TextMeshProUGUI> _pricesEnergy;
        [SerializeField] private List<TextMeshProUGUI> _productionTroopQueue;

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

        public void ConfigurePage(List<TroopsPageParameters> troopsPageParameters)
        {
            _pageParameters = troopsPageParameters;
            for (int i = 0; i < _pageParameters.Count; i++)
            {
                _images[i].sprite = troopsPageParameters[i].Image;
                _names[i].text = troopsPageParameters[i].Name;
                _pricesCrystals[i].text = troopsPageParameters[i].BuyingPriceCrystal.ToString();
                _pricesEnergy[i].text = troopsPageParameters[i].BuyingPriceEnergy.ToString();
                _pricesFood[i].text = troopsPageParameters[i].BuyingPriceFood.ToString();
                _productionTroopQueue[i].text = troopsPageParameters[i].ProductionTroopQueue.ToString();
            }
        }

        private void PressedButton1()
        {

        }

        private void PressedButton2()
        {

        }

        private void PressedButton3()
        {

        }


    }
}