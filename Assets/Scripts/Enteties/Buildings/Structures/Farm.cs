using System;
using Systems.Events;
using UnityEngine;

namespace Enteties.Buildings
{
    public class Farm : BasicManufacturerBuild, IDestroyable
    {
        [SerializeField]  private int _producedFood;
        
        
        public override void StartManufacture()
        {
            producedResources = _producedFood;
            resourceModifyEvent = LevelEventManager.FoodModify;
            canManufacture = true;
        }
        public void Destroy()
        {
            throw new System.NotImplementedException();
        }
    }
}