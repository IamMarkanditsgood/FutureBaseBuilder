﻿using System;
using System.Collections.Generic;
using Entities.Army.Troops;
using UnityEngine;

namespace MainLevel
{
    [Serializable]
    public class LevelArmy
    {
        public static LevelArmy instance;
        
        [SerializeField] private List<TroopsManager> _troops;
        [SerializeField] private List<TroopTypes> _researchedTroops = new List<TroopTypes>();

        public List<TroopsManager> Troops
        {
            get => _troops;
            set => _troops = value;
        }
        public List<TroopTypes> ResearchedTroops
        {
            get => _researchedTroops;
            set => _researchedTroops = value;
        }
        public void Init()
        {
            instance = this;
        }
        public bool IsResearched(TroopTypes troop)
        {
            for (int i = 0; i < instance.ResearchedTroops.Count; i++)
            {
                if (troop == instance.ResearchedTroops[i])
                {
                    return true;
                }
            }

            return false;
        }

        public TroopsManager GetTroop(TroopTypes type)
        {
            foreach (var troop in instance.Troops)
            {
                if (troop.Type == type)
                {
                    return troop;
                }
            }
            return null;
        }
    }
}