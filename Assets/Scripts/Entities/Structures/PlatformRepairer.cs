using System;
using System.Collections.Generic;
using Systems.Events;
using Entities.Structures.Data_and_Enams;
using Entities.Structures.Platforms.PlatformsManagers;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Entities.Structures
{
    [Serializable]
    public class PlatformRepairer
    {
        [SerializeField] private List<BrokenPlatform> _brokenPlatforms;

        public void RepairPlatforms(BuildingLevels baseLevel, BuildingLevels maxStructureLevel)
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
                
                newPlatform.GetComponent<RepairedPlatform>().SpawnPoint = brokenPlatforms[i].SpawnPoint;
                
                Object.Destroy(brokenPlatforms[i].gameObject);
                _brokenPlatforms.Remove(brokenPlatforms[i]);
            }
        }
    }
}