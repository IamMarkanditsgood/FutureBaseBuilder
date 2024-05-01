using System;
using Entities.Structures.Buildings;
using Entities.Structures.Data_and_Enams;
using UnityEngine;

namespace Systems.Events
{
    public static class LevelEventManager
    {
        public static event Action<GameObject> OnStructureDestroyed;
        public static event Action<BuyingParameters> OnPurchasedBuildCreate;
        public static event Action<BasicBuildingManager> OnImprovePressed;
        public static event Action<int> OnСrystalsModify;
        public static event Action<int> OnFoodModify;
        public static event Action<int> OnEnergyModify;
        public static event Action<int> OnPowerModify;
        public static event Action<BuildingLevels> OnBaseImprove;

        public static event Action OnUIPanelsOpened;
        public static event Action OnUIPanelsClosed;

        public static void StructureDestroy(GameObject build)
        {
            OnStructureDestroyed?.Invoke(build);
        }
        public static void ImprovePressed(BasicBuildingManager basicBuildingManager)
        {
            OnImprovePressed?.Invoke(basicBuildingManager);
        }

        public static void CreatePurchasedBuild(BuyingParameters buyingParameters)
        {
            OnPurchasedBuildCreate?.Invoke(buyingParameters);
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

        public static void BaseImproved(BuildingLevels baseLevel)
        {
            OnBaseImprove?.Invoke(baseLevel);
        }

        public static void OpenUI()
        {
            OnUIPanelsOpened?.Invoke();
        }
        public static void CloseUI()
        {
            OnUIPanelsClosed?.Invoke();
        }
    }
}