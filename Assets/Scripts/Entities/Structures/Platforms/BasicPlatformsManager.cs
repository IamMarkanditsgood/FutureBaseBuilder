using Systems;
using Entities.Structures.Data_and_Enams;
using UnityEngine;
using UnityEngine.Serialization;

namespace Entities.Structures.Platforms
{
    public abstract class BasicPlatformsManager : MonoBehaviour, ISavableStructure
    {
        [SerializeField] protected bool _isActive;
        [SerializeField] protected GameObject _spawnPoint;
        [FormerlySerializedAs("_savedStructuresTypeType")] [FormerlySerializedAs("_savedStructuresType")] [SerializeField] private StructureTypes _structureTypesType;
        [FormerlySerializedAs("_savedStructureLevels")] [SerializeField] private StructureLevels _structureLevels;
        public GameObject SpawnPoint
        {
            get => _spawnPoint;
            set => _spawnPoint = value;
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