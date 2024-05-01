using Systems.Events;

namespace Entities.Structures.Buildings.Military
{
    public class House : BasicBuildingManager
    {
        public override void OnMouseDown()
        {
            UIEventManager.ShowStructurePanel(this);
        }
        
       
    }
}