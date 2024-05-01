using Systems.Events;
using UnityEngine;

namespace Entities.Structures.Buildings.Manufacture
{
    public class Miner : BasicManufacturerBuild
    {
        [SerializeField]  private int _producedCrystals;
        
        public override void StartManufacture()
        {
            producedResources = _producedCrystals;
            resourceModifyEvent = LevelEventManager.СrystalsModify;
            canManufacture = true;
        }
    }
}