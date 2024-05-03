using System.Collections.Generic;
using Systems;
using Systems.Events;
using Entities.Structures;
using Entities.Structures.Buildings;
using Entities.Structures.Data_and_Enams;
using Entities.Structures.Platforms;
using Entities.Structures.Platforms.PlatformsManagers;
using MainLevel.Data;
using UnityEngine;

namespace MainLevel
{
    public class SceneSaverLoader
    {
        private StructureManager _structureManager;
        private List<GameObject> _structurePositions;
        
        public void Init(StructureManager structureManager, List<GameObject> structurePositions)
        {
            _structureManager = structureManager;
            _structurePositions = structurePositions;
        }
        
        private GameObject GetPositionPoint(Vector3 coordinates)
        {
            for (int i = 0; i < _structurePositions.Count; i++)
            {
                if (_structurePositions[i].transform.position == coordinates)
                {
                    return _structurePositions[i];
                }
            }

            return null;
        }
        
        #region SaveDATA
        public void SaveData(SavedData savedData)
        {
            savedData.CleanData();
            SaveTroopsData(savedData);
            SaveResourcesData(savedData);
            SaveStructuresData(savedData);
        }

        private void SaveTroopsData(SavedData savedData)
        {
            savedData.InitializeResearchedTroops(LevelArmy.instance.ResearchedTroops);
           
            for (int i = 0; i < LevelArmy.instance.Troops.Count; i++)
            {
                savedData.InitializeTroopAmountDictionary(LevelArmy.instance.Troops[i].NumberOfDivisions );
                savedData.InitializeTroopQueueAmountDictionary(LevelArmy.instance.Troops[i].QueueOfDivisions );
            }
        }

        private void SaveResourcesData(SavedData savedData)
        {
            savedData.InitializeResourcesAmountDictionary(LevelResources.instance.Crystals);
            savedData.InitializeResourcesAmountDictionary(LevelResources.instance.Energy);
            savedData.InitializeResourcesAmountDictionary(LevelResources.instance.Food);
            savedData.InitializeResourcesAmountDictionary(LevelResources.instance.BasePower);
        }

        private void SaveStructuresData(SavedData savedData)
        {
            for (int i = 0; i < LevelStructures.instance.StructuresOnScene.Count; i++)
            {
                savedData.InitializeBuildsCoordinates(LevelStructures.instance.StructuresOnScene[i].GetComponent<ISavableStructure>().GetSavedStructureCoordinates());
                savedData.InitializeBuildingsType(LevelStructures.instance.StructuresOnScene[i].GetComponent<ISavableStructure>().GetSavedStructureType());
                savedData.InitializeBuildingsLevel(LevelStructures.instance.StructuresOnScene[i].GetComponent<ISavableStructure>().GetSavedStructureLevel());
            }
        }
        

        #endregion

        #region Configure
        public void ConfigureScene(SavedData savedData)
        {
            ConfigureTroops(savedData);
            ConfigureResources(savedData);
            ConfigureBuildings(savedData);
        }

        private void ConfigureTroops(SavedData savedData)
        {
            LevelArmy.instance.ResearchedTroops = savedData.researchedTroops;
            
            for (int i = 0; i < LevelArmy.instance.Troops.Count; i++)
            {
                LevelArmy.instance.Troops[i].NumberOfDivisions = savedData.troopAmount[i];
                LevelArmy.instance.Troops[i].QueueOfDivisions = savedData.troopQueueAmount[i];
                
                if (LevelArmy.instance.Troops[i].QueueOfDivisions > 0)
                {
                    TroopsProducingEvents.ProduceTroop(LevelArmy.instance.Troops[i].Type);
                }
            }
        }

        private void ConfigureResources(SavedData savedData)
        {
            LevelResources.instance.Crystals = savedData.resourcesAmount[0];
            LevelResources.instance.Energy = savedData.resourcesAmount[1];
            LevelResources.instance.Food = savedData.resourcesAmount[2];
            LevelResources.instance.BasePower = savedData.resourcesAmount[3];
        }
        
        private void ConfigureBuildings(SavedData savedData)
        {

            CleanStructures();
            
            for (int i = 0; i < savedData.buildsCoordinates.Count; i++)
            {
                if (savedData.buildingsType[i] == StructureTypes.BrokenPlatform)
                {
                    ConfigureBrokenPlatform(savedData, i);
                }
                else if (savedData.buildingsType[i] == StructureTypes.Platform)
                {
                    ConfigurePlatform(savedData, i);
                }
                else
                {
                    ConfigureStructures(savedData, i);
                }
            }
            
        }

        private void ConfigureBrokenPlatform(SavedData savedData, int positionIndex)
        {
            GameObject buildPref = LevelPrefabs.instance.DestroyedFoundament;
            GameObject newObject = CreateNewStructure(buildPref, savedData, positionIndex);
            newObject.GetComponent<BasicPlatformsManager>().SpawnPoint = GetPositionPoint(savedData.buildsCoordinates[positionIndex]);
            _structureManager.PlatformRepairer.BrokenPlatforms.Add(newObject.GetComponent<BrokenPlatform>());
        }
        
        private void ConfigurePlatform(SavedData savedData, int positionIndex)
        {
            GameObject buildPref = LevelPrefabs.instance.Foundament;
            GameObject newObject = CreateNewStructure(buildPref, savedData, positionIndex);
            newObject.GetComponent<BasicPlatformsManager>().SpawnPoint = GetPositionPoint(savedData.buildsCoordinates[positionIndex]);
        }
        
        private void ConfigureStructures(SavedData savedData, int positionIndex)
        {
            GameObject buildPref = LevelPrefabs.instance.GetBuild(savedData.buildingsType[positionIndex], savedData.buildingsLevel[positionIndex]);
            GameObject newObject = CreateNewStructure(buildPref, savedData, positionIndex);
            newObject.GetComponent<BasicBuildingManager>().BuildsData.PlacePosition = GetPositionPoint(savedData.buildsCoordinates[positionIndex]);
        }

        private GameObject CreateNewStructure(GameObject pref , SavedData savedData, int positionIndex)
        {
            GameObject newObject = Object.Instantiate(pref, savedData.buildsCoordinates[positionIndex], Quaternion.identity);
            LevelStructures.instance.StructuresOnScene.Add(newObject);
            newObject.transform.parent = LevelStructures.instance.StructuresContainer;
            return newObject;
        }
        private void CleanStructures()
        {
            for (int i = 0; i < LevelStructures.instance.StructuresOnScene.Count; i++)
            {
                Object.Destroy(LevelStructures.instance.StructuresOnScene[i]);
                
            }
            LevelStructures.instance.StructuresOnScene = new List<GameObject>();
            _structureManager.PlatformRepairer.BrokenPlatforms = new List<BrokenPlatform>();
        }
        #endregion
        
        
    }
}