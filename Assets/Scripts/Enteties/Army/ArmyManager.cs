﻿using System;
using Systems.Events;
using UnityEngine;

namespace Enteties.Army
{
    [Serializable]
    public class ArmyManager
    {
        [SerializeField] private DivisionsManager _divisionsManager;
        [SerializeField] private ArmyResearchManager _armyResearchManager;

        public void Init()
        {
            Subscribe();
        }

        public void Disable()
        {
            UnSubscribe();
        }
        
        private void Subscribe()
        {
            //ResearchEvent.OnInfantryResearched
        }
        private void UnSubscribe()
        {
            
        }
    }
}