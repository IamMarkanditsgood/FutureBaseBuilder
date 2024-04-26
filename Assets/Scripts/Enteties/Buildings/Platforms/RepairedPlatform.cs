using Systems.Events;

namespace Enteties.Buildings.Platforms
{
    public class RepairedPlatform : BasicPlatformsManager
    {
        public override void OnMouseDown()
        {
            ByingParamethers buByingParamethers = new ByingParamethers();
            buByingParamethers.ChoosedPlatform = gameObject;
            buByingParamethers.ChoosetPosition = _spawnPosition;
            UIEventManager.ShowShopPanel(buByingParamethers);
                
        }
    }
}