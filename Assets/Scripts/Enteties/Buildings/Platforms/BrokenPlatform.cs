using Systems.Events;

namespace Enteties.Buildings.Platforms
{
    public class BrokenPlatform : BasicPlatformsManager
    {
        public override void OnMouseDown()
        {
            UIEventManager.ShowBrakePlatformWarning();
        }
    }
}