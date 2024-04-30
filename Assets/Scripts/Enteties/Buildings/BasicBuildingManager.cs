using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace Enteties.Buildings
{
    public abstract class BasicBuildingManager : MonoBehaviour
    {
        [SerializeField] protected BuildsData _buildsData;
        [SerializeField] protected bool _isInUse;
        [SerializeField] protected bool _canBeImproved = true;
        [SerializeField] protected bool _isUiOpened;

        public bool IsInUse
        {
            get => _isInUse;
            set
            {
                _isInUse = value;
                if (_isInUse && this is IManufacturer)
                {
                    IManufacturer manufacturer = (IManufacturer)this;
                    manufacturer.StartManufacture();
                }
                else if(!_isInUse && this is IManufacturer)
                {
                    IManufacturer manufacturer = (IManufacturer)this;
                    manufacturer.StopManufacture();
                }
            }
        }

        public bool CanBeImproved
        {
            get => _canBeImproved;
            set => _canBeImproved = value;
        }

        public BuildsData BuildsData
        {
            get { return _buildsData; }
            set { _buildsData = value; }
        }
        /// <summary>
        /// I need to change it on Pool Object
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
        public void Start()
        {
            IsInUse = true;
        }

        public void OnEnable()
        {
            IsInUse = true;
        }

        public abstract void OnMouseDown();

        public void OnDisable()
        {
            IsInUse = false;
        }
    }
}
