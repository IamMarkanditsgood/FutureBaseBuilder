using Systems.Events;
using UI.Level.Panels.Shop;

namespace Entities.Structures.Platforms.PlatformsManagers
{
    public class RepairedPlatform : BasicPlatformsManager
    {
        public override void OnMouseDown()
        {
            BuyingParameters buBuyingParameters = new BuyingParameters();
            
            buBuyingParameters.ChoosedPlatform = gameObject;
            buBuyingParameters.ChoosedPosition = _spawnPoint;
            
            UIEventManager.ShowShopPanel(buBuyingParameters);
                
        }
    }
}