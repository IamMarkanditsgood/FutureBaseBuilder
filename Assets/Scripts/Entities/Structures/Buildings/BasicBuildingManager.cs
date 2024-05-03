using Systems;
using Entities.Structures.Data_and_Enams;
using Entities.Structures.Interfaces;
using UnityEngine;
using UnityEngine.Serialization;

namespace Entities.Structures.Buildings
{
    public abstract class BasicBuildingManager : MonoBehaviour, ISavableStructure
    {
        [SerializeField] protected BuildsData _buildsData;
        [SerializeField] protected bool _isInUse;
        [SerializeField] protected bool _canBeImproved = true;
        [SerializeField] protected bool _canBeDestroyed;
        [FormerlySerializedAs("_savedStructuresTypeType")] [SerializeField] private StructureTypes _structureTypesType;
        [FormerlySerializedAs("_savedStructureLevels")] [SerializeField] private StructureLevels _structureLevels;
        
        protected bool isUiOpened;
        
        public bool CanBeDestroyed => _canBeDestroyed;
        
        public BuildsData BuildsData => _buildsData;
        
        public bool CanBeImproved
        {
            get => _canBeImproved;
            set => _canBeImproved = value;
        }
        
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
        public void Start()
        {
            IsInUse = true;
        }

        public void OnEnable()
        {
            IsInUse = true;
        }
        
        public void OnDisable()
        {
            IsInUse = false;
        }
        
        public abstract void OnMouseDown();
        public StructureTypes GetSavedStructureType()
        {
            return _structureTypesType;
        }

        public StructureLevels GetSavedStructureLevel()
        {
            return _structureLevels;
        }

        public Vector3 GetSavedStructureCoordinates()
        {
            return gameObject.transform.position;
        }
    }
}
