using Systems.Events;

namespace Entities.Structures.Platforms.PlatformsManagers
{
    public class BrokenPlatform : BasicPlatformsManager
    {
        public override void OnMouseDown()
        {
            UIEventManager.ShowBrakePlatformWarning();
        }
    }
}