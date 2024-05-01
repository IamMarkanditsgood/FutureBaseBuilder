using Systems.Events;
using UnityEngine;

namespace Enteties.Buildings
{
    public class ArmyCreator : BasicBuildingManager
    {
        public override void OnMouseDown()
        {
            UIEventManager.ShowStructurePanel(this);
        }
    }
}