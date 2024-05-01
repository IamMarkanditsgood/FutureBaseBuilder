using System;
using Systems.Events;
using UnityEngine;
using UnityEngine.Serialization;

namespace Enteties.Buildings
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