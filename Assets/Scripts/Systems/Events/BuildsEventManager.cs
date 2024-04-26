using System;
using Enteties.Buildings;

namespace Systems.Events
{
    public static class BuildsEventManager
    {
        public static event Action<BuildsData> OnShowStructurePanel;

        public static void ShowStructurePanel(BuildsData basicBuildingManager)
        {
            OnShowStructurePanel?.Invoke(basicBuildingManager);
        }
    }
}