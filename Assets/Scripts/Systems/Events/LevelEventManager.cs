using System;
using Enteties.Buildings;
using UnityEngine;

namespace Systems.Events
{
    public static class LevelEventManager
    {
        public static event Action<GameObject> OnStructureDestroyed;
        public static event Action<ByingParamethers> OnBuildBuyed;
        public static event Action<BasicBuildingManager> OnImprovePressed;
        public static event Action<int> OnСrystalsModify;
        public static event Action<int> OnFoodModify;
        public static event Action<int> OnEnergyModify;
        public static event Action<int> OnPowerModify;
        public static void StructureDestroy(GameObject build)
        {
            OnStructureDestroyed?.Invoke(build);
        }
        public static void ImprovePressed(BasicBuildingManager basicBuildingManager)
        {
            OnImprovePressed?.Invoke(basicBuildingManager);
        }

        public static void BuyBuild(ByingParamethers byingParamethers)
        {
            OnBuildBuyed?.Invoke(byingParamethers);
        }
        public static void СrystalsModify(int amount)
        {
            OnСrystalsModify?.Invoke(amount);
        }
        public static void EnergyModify(int amount)
        {
            OnEnergyModify?.Invoke(amount);
        }
        public static void FoodModify(int amount)
        {
            OnFoodModify?.Invoke(amount);
        }
        public static void PowerModify(int amount)
        {
            OnPowerModify?.Invoke(amount);
        }

    }
}