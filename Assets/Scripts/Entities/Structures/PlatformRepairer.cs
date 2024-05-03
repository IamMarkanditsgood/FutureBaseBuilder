using System;
using System.Collections.Generic;
using Systems;
using Systems.Events;
using Entities.Structures.Data_and_Enams;
using Entities.Structures.Platforms.PlatformsManagers;
using MainLevel.Data;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Entities.Structures
{
    [Serializable]
    public class PlatformRepairer
    {
        [SerializeField] private List<BrokenPlatform> _brokenPlatforms;

        public List<BrokenPlatform> BrokenPlatforms
        {
            get => _brokenPlatforms;
            set => _brokenPlatforms = value;
        }

        public void RepairPlatforms(StructureLevels baseLevel, StructureLevels maxStructureLevel)
        {
            List<BrokenPlatform> brokenPlatforms = new List<BrokenPlatform>();
            
            int countToAdd = baseLevel != maxStructureLevel ? _brokenPlatforms.Count / 2 : _brokenPlatforms.Count;

            for (int i = 0; i < countToAdd; i++)
            {
                brokenPlatforms.Add(_brokenPlatforms[i]);
            }

            PutNewPlatforms(brokenPlatforms);
        }

        private void PutNewPlatforms(List<BrokenPlatform> brokenPlatforms)
        {
            for (int i = 0; i < brokenPlatforms.Count; i++)
            {
                Transform spawnPosition = brokenPlatforms[i].SpawnPoint.transform;
                GameObject newPlatform = Object.Instantiate(LevelPrefabs.instance.Foundament, spawnPosition.position, Quaternion.identity);
                newPlatform.transform.parent = LevelStructures.instance.StructuresContainer;
                LevelStructures.instance.StructuresOnScene.Add(newPlatform);
                
                newPlatform.GetComponent<RepairedPlatform>().SpawnPoint = brokenPlatforms[i].SpawnPoint;
                
                LevelStructures.instance.StructuresOnScene.Remove(brokenPlatforms[i].gameObject);
                _brokenPlatforms.Remove(brokenPlatforms[i]);
                Object.Destroy(brokenPlatforms[i].gameObject);
            }
        }
    }
}