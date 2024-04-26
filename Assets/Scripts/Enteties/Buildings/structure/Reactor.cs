using Systems.Events;
using UnityEngine;

namespace Enteties.Buildings
{
    public class Reactor : BasicBuildingManager, IDestroyable, IImprovable, IManufacturer
    {
        public override void OnMouseDown()
        {
            UIEventManager.ShowStructurePanel(this);
        }
        
        public void Destroy()
        {
            
        }

        public void Improve()
        {
            throw new System.NotImplementedException();
        }

        public void Manufacture()
        {
            throw new System.NotImplementedException();
        }
    }
}