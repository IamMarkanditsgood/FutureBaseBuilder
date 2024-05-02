using System;
using UnityEngine;

namespace MainLevel.Data
{
    [Serializable]
    public class LevelResources
    {
        public static LevelResources instance;
        
        [SerializeField] private int _crystals;
        [SerializeField] private int _food;
        [SerializeField] private int _energy;
        [SerializeField] private int _basePower;
        
        public void Init()
        {
            instance = this;
        }
        
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

        public void ModifyResource(int amount, ResourceTypes type)
        {
            switch (type)
            {
                case ResourceTypes.Crystals:
                    _crystals += amount;
                    break;
                case ResourceTypes.Energy:
                    _energy += amount;
                    break;
                case ResourceTypes.Food:
                    _food += amount;
                    break;
                case ResourceTypes.Power:
                    _basePower += amount;
                    break;
            }
        }
        public bool IsEnoughResources(int crystals, int energy, int food)
        {
            if (crystals <= _crystals && energy <= _energy && food <= _food)
            {
                return true;
            }

            return false;
        }
    }
}