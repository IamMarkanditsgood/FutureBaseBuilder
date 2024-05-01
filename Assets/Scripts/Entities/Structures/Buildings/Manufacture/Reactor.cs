using Systems.Events;
using UnityEngine;
using UnityEngine.Serialization;

namespace Enteties.Buildings
{
    public class Reactor : BasicManufacturerBuild
    {
        [SerializeField]  private int _producedEnergy;
        
        
        public override void StartManufacture()
        {
            producedResources = _producedEnergy;
            resourceModifyEvent = LevelEventManager.EnergyModify;
            canManufacture = true;
        }
    }
}