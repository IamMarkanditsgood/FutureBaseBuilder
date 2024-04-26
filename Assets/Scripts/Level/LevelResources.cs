using System;
using UnityEngine;

namespace Level
{
    [Serializable]
    public class LevelResources
    {
        [SerializeField] private int _crystals;
        [SerializeField] private int _food;
        [SerializeField] private int _energy;
        [SerializeField] private int _basePower;
        public int Crystals
        {
            get => _crystals;
            set => _crystals = value;
        }

        public int Food
        {
            get => _food;
            set => _food = value;
        }

        public int Energy
        {
            get => _energy;
            set => _energy = value;
        }
        
        public int BasePower
        {
            get => _basePower;
            set => _basePower = value;
        }

        public void ModifyEnergy(int amount)
        {
            _energy += amount;
        }

        public void ModifyCrystals(int amount)
        {
            _crystals += amount;
        }

        public void ModifyFood(int amount)
        {
            _food += amount;
        }
        public void ModifyPower(int amount)
        {
            _basePower += amount;
        }
        
    }
}