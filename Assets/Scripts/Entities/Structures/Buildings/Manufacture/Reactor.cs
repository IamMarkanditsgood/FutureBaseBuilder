using Systems.Events;
using UnityEngine;

namespace Entities.Structures.Buildings.Manufacture
{
    public class Reactor : BasicManufacturerBuild
    {
        [SerializeField]  private int _producedEnergy;
        
        public override void StartManufacture()
        {
            producedResources = _producedEnergy;
            resourceModifyEvent = ResourcesEventManager.ResourceModify;
            canManufacture = true;
        }
    }
}