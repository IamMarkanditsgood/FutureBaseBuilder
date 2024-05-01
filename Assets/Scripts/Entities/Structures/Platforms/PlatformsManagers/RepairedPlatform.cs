using Systems.Events;

namespace Entities.Structures.Platforms.PlatformsManagers
{
    public class RepairedPlatform : BasicPlatformsManager
    {
        public override void OnMouseDown()
        {
            BuyingParameters buBuyingParameters = new BuyingParameters();
            
            buBuyingParameters.ChoosedPlatform = gameObject;
            buBuyingParameters.ChoosetPosition = _spawnPoint;
            
            UIEventManager.ShowShopPanel(buBuyingParameters);
                
        }
    }
}