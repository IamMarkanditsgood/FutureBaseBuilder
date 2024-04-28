using System;
using System.Collections.Generic;
using Systems.Events;
using Enteties.Army;
using Level;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Level
{
    public class ResearchPanelManager : BasicPanelManager
    {
        [SerializeField] private Button _infantryResearch;
        [SerializeField] private Button _APCResearch;
        [SerializeField] private Button _tankResearch;
        [SerializeField] private Button _helicopterResearch;
        [SerializeField] private Button _planeResearch;
        [SerializeField] private int _researchResources;
        private List<TroopTypes> _researchedTroops = new List<TroopTypes>();
        
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
            _close.onClick.AddListener(ClosePanel);
            _infantryResearch.onClick.AddListener(ResearchInfantry);
            _APCResearch.onClick.AddListener(ResearchAPC);
            _tankResearch.onClick.AddListener(ResearchTank);
            _helicopterResearch.onClick.AddListener(ResearchHelicopter);
            _planeResearch.onClick.AddListener(ResearchPlane);
        }

        private void Unsubscribe()
        {
            _close.onClick.RemoveListener(ClosePanel);
            _infantryResearch.onClick.RemoveListener(ResearchInfantry);
            _APCResearch.onClick.RemoveListener(ResearchAPC);
            _tankResearch.onClick.RemoveListener(ResearchTank);
            _helicopterResearch.onClick.RemoveListener(ResearchHelicopter);
            _planeResearch.onClick.RemoveListener(ResearchPlane);
        }
        
        
        private void ResearchInfantry()
        {
            if (!IsResearched(TroopTypes.Infantry) && LevelResources.instance.Crystals >= _researchResources && LevelResources.instance.Energy >= _researchResources &&LevelResources.instance.Food >= _researchResources)
            {
                _researchedTroops.Add(TroopTypes.Infantry);
                _APCResearch.interactable = true;
                ResearchEvent.ResearchTroop(TroopTypes.Infantry);
                
                LevelEventManager.EnergyModify(-_researchResources);
                LevelEventManager.FoodModify(-_researchResources);
                LevelEventManager.СrystalsModify(-_researchResources);
            }
        }
        private void ResearchAPC()
        {
            if (!IsResearched(TroopTypes.APC) && LevelResources.instance.Crystals >= _researchResources && LevelResources.instance.Energy >= _researchResources &&LevelResources.instance.Food >= _researchResources)
            {
                _researchedTroops.Add(TroopTypes.APC);
                _tankResearch.interactable = true;
                ResearchEvent.ResearchTroop(TroopTypes.APC);
                LevelEventManager.EnergyModify(-_researchResources);
                LevelEventManager.FoodModify(-_researchResources);
                LevelEventManager.СrystalsModify(-_researchResources);
            }
        }
        private void ResearchTank()
        {
            if (!IsResearched(TroopTypes.Tank) && LevelResources.instance.Crystals >= _researchResources && LevelResources.instance.Energy >= _researchResources &&LevelResources.instance.Food >= _researchResources)
            {
                _researchedTroops.Add(TroopTypes.Tank);
                _helicopterResearch.interactable = true;
                ResearchEvent.ResearchTroop(TroopTypes.Tank);
                LevelEventManager.EnergyModify(-_researchResources);
                LevelEventManager.FoodModify(-_researchResources);
                LevelEventManager.СrystalsModify(-_researchResources);
            }
        }
        private void ResearchHelicopter()
        {
            if (!IsResearched(TroopTypes.Helicopter)  && LevelResources.instance.Crystals >= _researchResources && LevelResources.instance.Energy >= _researchResources &&LevelResources.instance.Food >= _researchResources)
            {
                _researchedTroops.Add(TroopTypes.Helicopter);
                _planeResearch.interactable = true;
                ResearchEvent.ResearchTroop(TroopTypes.Helicopter);
                LevelEventManager.EnergyModify(-_researchResources);
                LevelEventManager.FoodModify(-_researchResources);
                LevelEventManager.СrystalsModify(-_researchResources);
            }
        }
        private void ResearchPlane()
        {
            if (!IsResearched(TroopTypes.Plane) && LevelResources.instance.Crystals >= _researchResources && LevelResources.instance.Energy >= _researchResources &&LevelResources.instance.Food >= _researchResources)
            {
                _researchedTroops.Add(TroopTypes.Plane);
                ResearchEvent.ResearchTroop(TroopTypes.Plane);
                LevelEventManager.EnergyModify(-_researchResources);
                LevelEventManager.FoodModify(-_researchResources);
                LevelEventManager.СrystalsModify(-_researchResources);
            }
        }

        private bool IsResearched(TroopTypes troop)
        {
            for (int i = 0; i < _researchedTroops.Count; i++)
            {
                if (_researchedTroops[i] == troop)
                {
                    return true;
                }
            }
            return false;
        }
        
    }
    
    
}