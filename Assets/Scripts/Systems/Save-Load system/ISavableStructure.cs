using Entities.Structures.Data_and_Enams;
using UnityEngine;

namespace Systems
{
    public interface ISavableStructure
    {
        public StructureTypes GetSavedStructureType();
        public StructureLevels GetSavedStructureLevel();
        public Vector3 GetSavedStructureCoordinates();
    }
}