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
            platform.transform.parent = LevelStructures.instance.StructuresContainer;
            
            BasicPlatformsManager basicPlatformsManager = platform.GetComponent<BasicPlatformsManager>();
            basicPlatformsManager.SpawnPoint = structure.GetComponent<BasicBuildingManager>().BuildsData.PlacePosition;
            
            LevelStructures.instance.StructuresOnScene.Add(platform);
            LevelStructures.instance.StructuresOnScene.Remove(structure);
            Object.Destroy(structure);
        }
    }
}