using Systems.Events;
using UnityEngine;

namespace Enteties.Buildings
{
    public class House : BasicBuildingManager
    {
        public override void OnMouseDown()
        {
            UIEventManager.ShowStructurePanel(this);
        }
        
       
    }
}