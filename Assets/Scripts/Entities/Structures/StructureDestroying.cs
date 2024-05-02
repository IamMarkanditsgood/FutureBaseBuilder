using Entities.Structures.Buildings;
using Entities.Structures.Platforms;
using MainLevel.Data;
using UnityEngine;

namespace Entities.Structures
{
    public class StructureDestroying
    {
        public void DestroyStructure(GameObject structure)
        {
            Transform spawnPosition = structure.GetComponent<BasicBuildingManager>().BuildsData.PlacePosition.transform;
            GameObject platform = Object.Instantiate(LevelPrefabs.instance.Foundament,spawnPosition.position, structure.transform.rotation);
            
            BasicPlatformsManager basicPlatformsManager = platform.GetComponent<BasicPlatformsManager>();
            basicPlatformsManager.SpawnPoint = structure.GetComponent<BasicBuildingManager>().BuildsData.PlacePosition;
            
            Object.Destroy(structure);
        }
    }
}