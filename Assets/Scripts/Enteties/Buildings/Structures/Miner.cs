using System;
using Systems.Events;
using UnityEngine;
using UnityEngine.Serialization;

namespace Enteties.Buildings
{
    public class Miner : BasicManufacturerBuild, IDestroyable
    {
        [SerializeField]  private int _producedCrystals;
        
        public override void StartManufacture()
        {
            producedResources = _producedCrystals;
            resourceModifyEvent = LevelEventManager.СrystalsModify;
            canManufacture = true;
        }
        public void Destroy()
        {
            throw new System.NotImplementedException();
        }
    }
}