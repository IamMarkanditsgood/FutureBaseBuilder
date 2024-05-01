using Systems.Events;

namespace Entities.Army
{
    public class ArmyManager
    {
        private readonly ArmyResearchManager _armyResearchManager =new ArmyResearchManager();
        private readonly ArmyProduceManager _armyProduceManager = new ArmyProduceManager();
        
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
}