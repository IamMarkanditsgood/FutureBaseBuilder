using System;
using Entities.Army.Troops;

namespace Systems.Events
{
    public static class TroopsProducingEvents
    {
        public static event Action<TroopTypes> OnTroopProduce;
        public static event Action<TroopTypes> OnProducingFinished;

        public static void ProduceTroop(TroopTypes producedTroop)
        {
            OnTroopProduce?.Invoke(producedTroop);
        }
        
        public static void ProducingFinished(TroopTypes producedTroop)
        {
            OnProducingFinished?.Invoke(producedTroop);
        }
        
    }
}