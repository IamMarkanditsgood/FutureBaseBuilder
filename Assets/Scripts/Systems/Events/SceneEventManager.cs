using System;
using Entities.Structures.Data_and_Enams;

namespace Systems.Events
{
    public static class SceneEventManager
    {
        public static event Action<StructureLevels> OnBaseImprove;
        public static event Action OnSceneRoofClose;
        public static event Action OnSceneRoofOpen;
        public static event Action OnMainMenuPressed;
        
        public static void BaseImproved(StructureLevels baseLevel)
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

        public static void MainMenuPressed()
        {
            OnMainMenuPressed?.Invoke();
        }
    }
}