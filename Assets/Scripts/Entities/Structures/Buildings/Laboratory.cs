using Systems.Events;

namespace Entities.Structures.Buildings
{
    public class Laboratory : BasicBuildingManager
    {
        public override void OnMouseDown()
        {
            UIEventManager.ShowStructurePanel(this);
        }
    }
}