using System;
using Enteties.Buildings;

namespace Systems.Events
{
    public static class UIEventManager
    {
        public static event Action<BasicBuildingManager> OnShowStructurePanel;
        public static event Action<ByingParamethers> OnShowShopPanel;
        public static event Action OnBrakePlatformPressed;

        public static void ShowStructurePanel(BasicBuildingManager basicBuildingManager)
        {
            OnShowStructurePanel?.Invoke(basicBuildingManager);
        }
        public static void ShowShopPanel(ByingParamethers byingParamethers)
        {
            OnShowShopPanel?.Invoke(byingParamethers);
        }
        
        public static void ShowBrakePlatformWarning()
        {
            OnBrakePlatformPressed?.Invoke();
        }
    }
}