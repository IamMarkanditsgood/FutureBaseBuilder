using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Systems.Events;
using UnityEditor;
using UnityEngine;

namespace Enteties.Army
{
    [Serializable]
    public class ArmyManager
    {
        [SerializeField] private ArmyResearchManager _armyResearchManager;
        [SerializeField] private ArmyProduceManager _armyProduceManager;
        
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
            ResearchEvent.OnTroopResearched += _armyResearchManager.ResearchTroop;
            TroopsProducingEvents.OnTroopProduce += _armyProduceManager.StartToProduceTroop;
        }
        private void UnSubscribe()
        {
            ResearchEvent.OnTroopResearched -= _armyResearchManager.ResearchTroop;
            TroopsProducingEvents.OnTroopProduce -= _armyProduceManager.StartToProduceTroop;
        }
    }
}