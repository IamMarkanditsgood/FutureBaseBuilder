using System;
using System.Collections.Generic;
using Systems.Events;
using Entities.Army.Troops;
using MainLevel.Data;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Level.Panels.Laboratory
{
    public class ResearchPanelManager : BasicPanelManager
    {
         [SerializeField] private Button[] _researchButtons;
    [SerializeField] private int _researchResources;
    
    private Dictionary<TroopTypes, bool> _researchedTroops = new Dictionary<TroopTypes, bool>();

    private void Start()
    {
        Subscribe();
        InitializeResearchStatus();
    }

    private void OnDestroy()
    {
        Unsubscribe();
    }

    private void Subscribe()
    {
        _close.onClick.AddListener(ClosePanel);
        foreach (var button in _researchButtons)
        {
            button.onClick.AddListener(() => ResearchTroop((TroopTypes)System.Enum.Parse(typeof(TroopTypes), button.name)));
        }
    }

    private void Unsubscribe()
    {
        _close.onClick.RemoveListener(ClosePanel);
        foreach (var button in _researchButtons)
        {
            button.onClick.RemoveAllListeners();
        }
    }

    private void InitializeResearchStatus()
    {
        foreach (var troopType in (TroopTypes[])Enum.GetValues(typeof(TroopTypes)))
        {
            _researchedTroops[troopType] = false;
        }
    }

    private void ResearchTroop(TroopTypes troopType)
    {
        if (!_researchedTroops.ContainsKey(troopType))
        {
            return;
        }

        if (!HasEnoughResources())
        {
            return;
        }

        _researchedTroops[troopType] = true;
        ResearchEvent.ResearchTroop(troopType);
        UpdateResearchButton();
        ConsumeResources();
    }

    private bool HasEnoughResources()
    {
        return LevelResources.instance.Crystals >= _researchResources &&
               LevelResources.instance.Energy >= _researchResources &&
               LevelResources.instance.Food >= _researchResources;
    }

    private void ConsumeResources()
    {
        ResourcesEventManager.ResourceModify(-_researchResources, ResourceTypes.Crystals);
        ResourcesEventManager.ResourceModify(-_researchResources, ResourceTypes.Energy);
        ResourcesEventManager.ResourceModify(-_researchResources, ResourceTypes.Food);
    }

    private void UpdateResearchButton()
    {
        for (int i = 0; i < _researchButtons.Length; i++)
        {
            if (!_researchButtons[i].interactable)
            {
                _researchButtons[i].interactable = true;
                return;
            }
        }
    }
    }
}