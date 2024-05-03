using Systems.Events;
using Entities.Structures.Interfaces;

namespace Entities.Structures.Buildings
{
    public class MainBase : BasicBuildingManager, IBaseImprover
    {
        public override void OnMouseDown()
        {
            UIEventManager.ShowStructurePanel(this);
        }
        
        public void Improve()
        {
            SceneEventManager.BaseImproved(GetSavedStructureLevel());

        }
    }
}