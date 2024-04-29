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
        [SerializeField] private TroopsProducing _divisionsManager;
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
    [Serializable]
    public class ArmyProduceManager
    {
        [SerializeField] private List<TroopsProducing> _troops;
        public void StartToProduceTroop(TroopTypes type)
        {
            AddInQueue(type);
            for (int i = 0; i < _troops.Count; i++)
            {
                _troops[i].Produce();
            }
        }

        private void AddInQueue(TroopTypes type)
        {
            for (int i = 0; i < _troops.Count; i++)
            {
                if (type == _troops[i].Type)
                {
                    _troops[i].QueueOfDivisions++;
                }
            }
        }
    }
    
    
    
}