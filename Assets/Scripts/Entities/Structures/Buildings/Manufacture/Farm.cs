using Systems.Events;
using UnityEngine;

namespace Entities.Structures.Buildings.Manufacture
{
    public class Farm : BasicManufacturerBuild
    {
        [SerializeField]  private int _producedFood;

        public override void StartManufacture()
        {
            producedResources = _producedFood;
            resourceModifyEvent = LevelEventManager.FoodModify;
            canManufacture = true;
        }
     
    }
}