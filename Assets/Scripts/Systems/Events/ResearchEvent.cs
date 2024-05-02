using System;
using Entities.Army.Troops;

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