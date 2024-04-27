using System;
using Enteties.Buildings;

namespace Systems.Events
{
    public static class UIEventManager
    {
        public static event Action<BasicBuildingManager> OnShowStructurePanel;
        public static event Action<BuyingParameters> OnShowShopPanel;
        public static event Action OnBrakePlatformPressed;
        public static event Action OnCloseAllPanels;

        public static void ShowStructurePanel(BasicBuildingManager basicBuildingManager)
        {
            OnShowStructurePanel?.Invoke(basicBuildingManager);
        }
        public static void ShowShopPanel(BuyingParameters buyingParameters)
        {
            OnShowShopPanel?.Invoke(buyingParameters);
        }
        
        public static void ShowBrakePlatformWarning()
        {
            OnBrakePlatformPressed?.Invoke();
        }
        public static void CloseAllPanels()
        {
            OnCloseAllPanels?.Invoke();
        }
    }
}