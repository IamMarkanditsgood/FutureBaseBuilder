using Entities.Army.Troops;
using MainLevel;
using MainLevel.Data;

namespace Entities.Army
{
    public class ArmyProduceManager
    {
        public void StartToProduceTroop(TroopTypes type)
        {
            AddInQueue(type);
            ProduceTroops(type);
        }

        private void AddInQueue(TroopTypes type)
        {
            TroopsManager troop = LevelArmy.instance.GetTroop(type);
            troop.QueueOfDivisions++;
        }

        private void ProduceTroops(TroopTypes type)
        {
            TroopsManager troop = LevelArmy.instance.GetTroop(type);
            troop.Produce();
        }
    }
}