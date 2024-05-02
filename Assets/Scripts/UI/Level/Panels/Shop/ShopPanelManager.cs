using System;
using System.Collections.Generic;
using TMPro;
using UI.Level.Panels.Shop.Page;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Level.Panels.Shop
{
    public class ShopPanelManager : BasicPanelManager
    {
        [Serializable]
        private struct Pages
        {
            public List<BuildBuyPanelParameters> buildParameters;
        }
    
        [SerializeField] private ShopPage _shopPage;
        [SerializeField] private List<Pages> _pages;
        [SerializeField] private Button _nextPageButton;
        [SerializeField] private Button _prevPageButton;
        [SerializeField] private TextMeshProUGUI _pageText;

        private BuyingParameters _buyingParameters;
        private int _currentPage;
    
        private void Start()
        {
            Subscribe();
        }
        
        private void OnDestroy()
        {
            Unsubscribe();
        }

        private void Subscribe()
        {
            _shopPage.Subscribe();
            _close.onClick.AddListener(ClosePanel);   
            _nextPageButton.onClick.AddListener(NextPage);
            _prevPageButton.onClick.AddListener(PrevPage);
        }

        private void Unsubscribe()
        {
            _shopPage.Unsubscribe();
            _close.onClick.RemoveListener(ClosePanel);    
            _nextPageButton.onClick.RemoveListener(NextPage);
            _prevPageButton.onClick.RemoveListener(PrevPage);
        }
        
        public void ConfigureShopPanel(BuyingParameters buyingParameters)
        {
            _buyingParameters = buyingParameters;
            _shopPage.ConfigureBuyingParameters(_buyingParameters, _pages[_currentPage].buildParameters, gameObject);
        }

        private void NextPage()
        {
            int lastPage = _pages.Count - 1;
            if (_currentPage == lastPage)
            {
                _currentPage = 0;
            }
            else
            {
                _currentPage++;
            }
            int textPage = _currentPage + 1;
            _pageText.text = textPage.ToString();
            _shopPage.ConfigureBuyingParameters(_buyingParameters, _pages[_currentPage].buildParameters, gameObject);
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
            _shopPage.ConfigureBuyingParameters(_buyingParameters, _pages[_currentPage].buildParameters, gameObject);
        }
    }
}