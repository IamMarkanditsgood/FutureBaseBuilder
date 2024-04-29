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
        [SerializeField] private DivisionsManager _divisionsManager;
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
        [SerializeField] private List<Troops> _troops;
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
    
    [Serializable]
    public class Troops
    {
        
        [SerializeField] private TroopTypes _type;
        [SerializeField] private int _damage;
        [SerializeField] private int _hp;
        [SerializeField] private int _numberOfDivisions;
        [SerializeField] private int _queueOfDivisions;
        [SerializeField] private float _produceTime;
        
        private bool _isProduce;

        public TroopTypes Type
        {
            get => _type;
            set => _type = value;
        }
        public int Damage
        {
            get => _damage;
            set => _damage = value;
        }
        public int Hp
        {
            get => _hp;
            set => _hp = value;
        }
        public int NumberOfDivisions
        {
            get => _numberOfDivisions;
            set => _numberOfDivisions = value;
        }
        public int QueueOfDivisions
        {
            get => _queueOfDivisions;
            set => _queueOfDivisions = value;
        }
        
        public async void Produce()
        {
            if (!_isProduce)
            {
                _isProduce = true;
                while (true)
                {
                    if (_queueOfDivisions != 0)
                    {
                        await Task.Delay((int) (_produceTime * 1000));
                        _queueOfDivisions--;
                        _numberOfDivisions++;
                        LevelEventManager.PowerModify(_damage);
                        TroopsProducingEvents.ProducingFinished(Type);
                    }
                    else
                    {
                        _isProduce = false;
                        break;
                    }
                }
                
            }
        }
    }
    
}