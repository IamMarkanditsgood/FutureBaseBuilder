using System;
using System.Collections;
using Systems.Events;
using UnityEngine;
using UnityEngine.Serialization;

namespace Enteties.Buildings
{
    public abstract class BasicManufacturerBuild : BasicBuildingManager, IManufacturer
    {
        [SerializeField] private float _producingInterval = 1f;
        
        protected int producedResources;
        protected Action<int> resourceModifyEvent;
        protected bool canManufacture;
        private float _timer = 0f;

        public void FixedUpdate()
        {
            if (canManufacture)
            {
                _timer += Time.fixedDeltaTime;

                if (_timer >= _producingInterval)
                {
                    _timer = 0f;
                    resourceModifyEvent?.Invoke(producedResources);
                }
            }
        }

        public override void OnMouseDown()
        {
            UIEventManager.ShowStructurePanel(this);
        }

        public abstract void StartManufacture();
        

        public void StopManufacture()
        {
            _timer = 0;
            canManufacture = false;
        }
        
    }
}