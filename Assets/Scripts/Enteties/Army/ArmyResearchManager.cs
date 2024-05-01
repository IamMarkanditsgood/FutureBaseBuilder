using System;
using System.Collections.Generic;
using Level;
using UnityEngine;

namespace Enteties.Army
{
    [Serializable]
    public class ArmyResearchManager
    {
        public void ResearchTroop(TroopTypes researchedTroop)
        {
            LevelArmyManager.instance.ResearchedTroops.Add(researchedTroop);
        }

        
    }
}