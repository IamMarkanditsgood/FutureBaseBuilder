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
    }
}