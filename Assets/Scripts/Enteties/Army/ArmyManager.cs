using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Systems.Events;
using Level;
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
    [Serializable]
    public class ArmyProduceManager
    {
        public void StartToProduceTroop(TroopTypes type)
        {
            AddInQueue(type);
            for (int i = 0; i < LevelArmy.instance.Troops.Count; i++)
            {
                LevelArmy.instance.Troops[i].Produce();
            }
        }

        private void AddInQueue(TroopTypes type)
        {
            for (int i = 0; i < LevelArmy.instance.Troops.Count; i++)
            {
                if (type == LevelArmy.instance.Troops[i].Type)
                {
                    LevelArmy.instance.Troops[i].QueueOfDivisions++;
                }
            }
        }
    }
    
    
    
}