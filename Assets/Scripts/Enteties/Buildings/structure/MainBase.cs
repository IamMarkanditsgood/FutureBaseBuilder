using Systems.Events;
using UnityEngine;

namespace Enteties.Buildings
{
    public class MainBase : BasicBuildingManager, IDestroyable, IImprovable
    {
        public override void OnMouseDown()
        {
            BuildsEventManager.ShowStructurePanel(_buildsData);
        }
        
        public void Destroy()
        {
            throw new System.NotImplementedException();
        }

        public void Improve()
        {
            throw new System.NotImplementedException();
        }
    }
}