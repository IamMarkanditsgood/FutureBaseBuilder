using Systems.Events;
using UnityEngine;

namespace Enteties.Buildings
{
    public class Laboratory : BasicBuildingManager, IDestroyable
    {
        public override void OnMouseDown()
        {
            UIEventManager.ShowLaboratoryPanel();
        }
        
        public void Destroy()
        {
            throw new System.NotImplementedException();
        }
    }
}