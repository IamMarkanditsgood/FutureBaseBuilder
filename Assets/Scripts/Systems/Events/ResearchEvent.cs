using System;
using Enteties.Army;
using UnityEngine;

namespace Systems.Events
{
    public static class ResearchEvent
    {
        public static event Action<TroopTypes> OnTroopResearched;
        
        
        public static void ResearchTroop(TroopTypes researchedTroop)
        {
            OnTroopResearched?.Invoke(researchedTroop);
        }
    }
}