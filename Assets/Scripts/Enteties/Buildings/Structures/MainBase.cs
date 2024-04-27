using Systems.Events;

namespace Enteties.Buildings
{
    public class MainBase : BasicBuildingManager, IBaseImprover
    {
        public override void OnMouseDown()
        {
            UIEventManager.ShowStructurePanel(this);
        }
        
        public void Improve()
        {
            LevelEventManager.BaseImproved(BuildsData.BuildingLevel);

        }
    }
}