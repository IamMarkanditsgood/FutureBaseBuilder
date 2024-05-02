using System;
using Entities.Structures.Data_and_Enams;

namespace Systems.Events
{
    public static class SceneEventManager
    {
        public static event Action<BuildingLevels> OnBaseImprove;
        public static event Action OnSceneRoofClose;
        public static event Action OnSceneRoofOpen;
        
        public static void BaseImproved(BuildingLevels baseLevel)
        {
            OnBaseImprove?.Invoke(baseLevel);
        }

        public static void OpenSceneRoof()
        {
            OnSceneRoofClose?.Invoke();
        }
        
        public static void CloseSceneRoof()
        {
            OnSceneRoofOpen?.Invoke();
        }
    }
}