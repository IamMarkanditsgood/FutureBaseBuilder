using System;
using Level;

namespace Enteties.Army
{
    [Serializable]
    public class ArmyProduceManager
    {
        public void StartToProduceTroop(TroopTypes type)
        {
            AddInQueue(type);
            for (int i = 0; i < LevelArmyManager.instance.Troops.Count; i++)
            {
                LevelArmyManager.instance.Troops[i].Produce();
            }
        }

        private void AddInQueue(TroopTypes type)
        {
            for (int i = 0; i < LevelArmyManager.instance.Troops.Count; i++)
            {
                if (type == LevelArmyManager.instance.Troops[i].Type)
                {
                    LevelArmyManager.instance.Troops[i].QueueOfDivisions++;
                }
            }
        }
    }
}