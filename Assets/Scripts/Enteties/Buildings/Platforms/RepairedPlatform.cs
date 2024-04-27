using Systems.Events;

namespace Enteties.Buildings.Platforms
{
    public class RepairedPlatform : BasicPlatformsManager
    {
        public override void OnMouseDown()
        {
            BuyingParameters buBuyingParameters = new BuyingParameters();
            buBuyingParameters.ChoosedPlatform = gameObject;
            buBuyingParameters.ChoosetPosition = _spawnPosition;
            UIEventManager.ShowShopPanel(buBuyingParameters);
                
        }
    }
}