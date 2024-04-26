using Systems.Events;
using UnityEngine;

namespace Enteties.Buildings
{
    public class MainBase : BasicBuildingManager, IImprovable
    {
        public override void OnMouseDown()
        {
            UIEventManager.ShowStructurePanel(this);
        }
        
        public void Improve()
        {
            throw new System.NotImplementedException();
        }
    }
}