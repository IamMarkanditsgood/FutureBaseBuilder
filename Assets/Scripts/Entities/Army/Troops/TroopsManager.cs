using System;
using System.Threading.Tasks;
using Systems.Events;
using MainLevel.Data;
using UnityEngine;

namespace Entities.Army.Troops
{
    [Serializable]
    public class TroopsManager
    {
        [SerializeField] private TroopTypes _type;
        [SerializeField] private int _damage;
        [SerializeField] private int _hp;
        [SerializeField] private int _numberOfDivisions;
        [SerializeField] private int _queueOfDivisions;
        [SerializeField] private float _produceTime;
        
        private bool _isProducing;

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

        public async Task Produce()
        {
            if (_isProducing)
            {
                return;
            }
            _isProducing = true;

            while (_queueOfDivisions > 0)
            {
                await Task.Delay(TimeSpan.FromSeconds(_produceTime));
                ProduceOneDivision();
            }

            _isProducing = false;
        }

        private void ProduceOneDivision()
        {
            _queueOfDivisions--;
            _numberOfDivisions++;
            ResourcesEventManager.ResourceModify(_damage,ResourceTypes.Power);
            TroopsProducingEvents.ProducingFinished(Type);
        }
    }
}