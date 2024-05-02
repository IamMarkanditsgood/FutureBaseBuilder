using System;
using Entities.Structures.Buildings;
using UnityEngine;

namespace Systems.Events
{
    public static class StructuresEventManager
    {
        public static event Action<GameObject> OnStructureDestroyed;
        public static event Action<BuyingParameters> OnPurchasedBuildCreate;
        public static event Action<BasicBuildingManager> OnImprovePressed;
        
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
    }
}