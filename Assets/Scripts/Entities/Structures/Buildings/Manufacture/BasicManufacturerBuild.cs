using System;
using Systems.Events;
using Entities.Structures.Interfaces;
using MainLevel.Data;
using UnityEngine;

namespace Entities.Structures.Buildings.Manufacture
{
    public abstract class BasicManufacturerBuild : BasicBuildingManager, IManufacturer
    {
        [SerializeField] private float _producingInterval = 1f;
        [SerializeField] private ResourceTypes _producedResource;
        
        protected int producedResources;
        protected Action<int, ResourceTypes> resourceModifyEvent;
        protected bool canManufacture;
        
        
        private float _timer;

        public void FixedUpdate()
        {
            if (canManufacture)
            {
                _timer += Time.fixedDeltaTime;

                if (_timer >= _producingInterval)
                {
                    _timer = 0f;
                    resourceModifyEvent?.Invoke(producedResources, _producedResource);
                }
            }
        }

        public override void OnMouseDown()
        {
            UIEventManager.ShowStructurePanel(this);
        }
        public void StopManufacture()
        {
            _timer = 0;
            canManufacture = false;
        }
        
        public abstract void StartManufacture();
        
        
    }
}