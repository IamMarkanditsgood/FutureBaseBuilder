using System;
using System.Collections;
using System.Collections.Generic;
using Systems.Events;
using Entities.Army.Troops;
using TMPro;
using UI.Level;
using UnityEngine;
using UnityEngine.ParticleSystemJobs;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class TroopsCreatorPanel : BasicPanelManager
{
    [Serializable]
    private struct Page
    {
        public List<TroopsPageParameters> troopsPageParameterses;
    }

    [SerializeField] private TroopCreatorPage _troopCreatorPage;
    [SerializeField] private List<Page> _pages;
    [SerializeField] private Button _nextPageButton;
    [SerializeField] private Button _prevPageButton;
    [SerializeField] private TextMeshProUGUI _pageText;

    private int _currentPage;

    public void Start()
    {
        Subscribe();
    }

    public override void Open()
    {
        _panel.SetActive(true);
        _currentPage = 0;
        int textPageNumber = _currentPage + 1;
        _pageText.text = textPageNumber.ToString();
        _troopCreatorPage.ConfigurePage(_pages[_currentPage].troopsPageParameterses);
    }
    
    private void OnDestroy()
    {
        Unsubscribe();
    }

    private void Subscribe()
    {
        _close.onClick.AddListener(ClosePanel);   
        _nextPageButton.onClick.AddListener(NextPage);
        _prevPageButton.onClick.AddListener(PrevPage);
        _troopCreatorPage.Subscribe();
        TroopsProducingEvents.OnProducingFinished += RemoveFromProductionQueue;
    }

    private void Unsubscribe()
    {
        _close.onClick.RemoveListener(ClosePanel);   
        _nextPageButton.onClick.RemoveListener(NextPage);
        _prevPageButton.onClick.RemoveListener(PrevPage);
        _troopCreatorPage.Unsubscribe();
        TroopsProducingEvents.OnProducingFinished -= RemoveFromProductionQueue;
    }

    private void RemoveFromProductionQueue(TroopTypes producedTroop)
    {
        for (int i = 0;i < _pages.Count;i++)
        {
            for (int j = 0; j < _pages[i].troopsPageParameterses.Count; j++)
            {
                if (_pages[i].troopsPageParameterses[j].TroopType == producedTroop)
                {
                    _pages[i].troopsPageParameterses[j].ProducedTroopsQueue--;
                }
            }
        }
        _troopCreatorPage.ConfigurePage(_pages[_currentPage].troopsPageParameterses);
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
        _troopCreatorPage.ConfigurePage(_pages[_currentPage].troopsPageParameterses);
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
        _troopCreatorPage.ConfigurePage(_pages[_currentPage].troopsPageParameterses);
    }

    
}