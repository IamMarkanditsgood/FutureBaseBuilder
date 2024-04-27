using Systems.Events;
using UnityEngine;
using UnityEngine.Serialization;

namespace Enteties.Buildings
{
    public class Reactor : BasicManufacturerBuild, IDestroyable
    {
        [SerializeField]  private int _producedEnergy;
        
        
        public override void StartManufacture()
        {
            producedResources = _producedEnergy;
            resourceModifyEvent = LevelEventManager.EnergyModify;
            canManufacture = true;
        }
        public void Destroy()
        {
            throw new System.NotImplementedException();
        }
    }
}