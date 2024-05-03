using System;
using System.Collections.Generic;
using Systems;
using Entities.Structures.Buildings;
using Entities.Structures.Data_and_Enams;
using UnityEngine;

namespace MainLevel.Data
{
    [Serializable]
    public class LevelPrefabs
    {
        public static LevelPrefabs instance;
        [SerializeField] private GameObject _foundament;
        [SerializeField] private GameObject _destroyedFoundament;
        [SerializeField] private List<GameObject> _buildsList;

        public GameObject Foundament => _foundament;
        public GameObject DestroyedFoundament => _destroyedFoundament;
        public List<GameObject> BuildsList => _buildsList;

        public void Init()
        {
            instance = this;
        }
    
        public GameObject GetBuild(StructureTypes buildingTypes, StructureLevels buildingLevels)
        {
            for (int i = 0; i < BuildsList.Count; i++)
            {
                if (BuildsList[i].GetComponent<ISavableStructure>().GetSavedStructureType() == buildingTypes &&
                    BuildsList[i].GetComponent<ISavableStructure>().GetSavedStructureLevel() == buildingLevels)
                {
                    return BuildsList[i];
                }
            }

            return null;
        }
    }
}