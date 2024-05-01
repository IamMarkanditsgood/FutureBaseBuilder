using Systems.Events;
using UnityEngine;

namespace Enteties.Buildings
{
    public class Laboratory : BasicBuildingManager
    {
        public override void OnMouseDown()
        {
            UIEventManager.ShowStructurePanel(this);
        }
    }
}