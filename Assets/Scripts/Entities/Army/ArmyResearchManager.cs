using Entities.Army.Troops;
using MainLevel;
using MainLevel.Data;

namespace Entities.Army
{
    public class ArmyResearchManager
    {
        public void ResearchTroop(TroopTypes researchedTroop)
        {
            LevelArmy.instance.ResearchedTroops.Add(researchedTroop);
        }
    }
}