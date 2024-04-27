using System;
using System.Collections.Generic;
using Systems.Events;
using Enteties.Army;
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

        private ArmyResearchPanelManager _armyResearchPanelManager;
        
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
            _infantryResearch.onClick.AddListener(_armyResearchPanelManager.ResearchInfantry);
            _APCResearch.onClick.AddListener(_armyResearchPanelManager.ResearchAPC);
            _tankResearch.onClick.AddListener(_armyResearchPanelManager.ResearchTank);
            _helicopterResearch.onClick.AddListener(_armyResearchPanelManager.ResearchHelicopter);
            _planeResearch.onClick.AddListener(_armyResearchPanelManager.ResearchPlane);
        }

        private void Unsubscribe()
        {
            _close.onClick.RemoveListener(ClosePanel);
            _infantryResearch.onClick.RemoveListener(_armyResearchPanelManager.ResearchInfantry);
            _APCResearch.onClick.RemoveListener(_armyResearchPanelManager.ResearchAPC);
            _tankResearch.onClick.RemoveListener(_armyResearchPanelManager.ResearchTank);
            _helicopterResearch.onClick.RemoveListener(_armyResearchPanelManager.ResearchHelicopter);
            _planeResearch.onClick.RemoveListener(_armyResearchPanelManager.ResearchPlane);
        }
        
        
    }
    
    public class ArmyResearchPanelManager
    {
        private List<TroopTypes> _researchedTroops = new List<TroopTypes>() { TroopTypes.Infantry };
        
        public void ResearchInfantry()
        {
            if (!IsResearched(TroopTypes.Infantry))
            {
                _researchedTroops.Add(TroopTypes.Infantry);
                ResearchEvent.ResearchInfantry();
            }
        }
        public void ResearchAPC()
        {
            ResearchEvent.ResearchInfantry();
        }
        public void ResearchTank()
        {
            ResearchEvent.ResearchInfantry();
        }
        public void ResearchHelicopter()
        {
            ResearchEvent.ResearchInfantry();
        }
        public void ResearchPlane()
        {
            ResearchEvent.ResearchInfantry();
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