using System;
using System.Collections.Generic;
using UnityEngine;

namespace Enteties.Army
{
    [Serializable]
    public class ArmyResearchManager
    {
        [SerializeField] private List<TroopTypes> _researchedTroops = new List<TroopTypes>();

        public void ResearchTroop(TroopTypes researchedTroop)
        {
            _researchedTroops.Add(researchedTroop);
        }

        public bool IsResearched(TroopTypes troop)
        {
            for (int i = 0; i < _researchedTroops.Count; i++)
            {
                if (troop == _researchedTroops[i])
                {
                    return true;
                }
            }

            return false;
        }
    }
}