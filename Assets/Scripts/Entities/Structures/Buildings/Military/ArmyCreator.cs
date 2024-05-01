using Systems.Events;

namespace Entities.Structures.Buildings.Military
{
    public class ArmyCreator : BasicBuildingManager
    {
        public override void OnMouseDown()
        {
            UIEventManager.ShowStructurePanel(this);
        }
    }
}