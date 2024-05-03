using System.Collections.Generic;
using Systems;
using Entities.Structures.Buildings;
using Entities.Structures.Data_and_Enams;
using MainLevel.Data;
using UI.Level.Panels.Shop;
using UnityEngine;

namespace Entities.Structures
{
    public class StructureCreation
    {
        public void CreatePurchasedBuild(BuyingParameters buyingParameters)
        {
            GameObject pref = FindStructureByType(buyingParameters.BuildingTypes, StructureLevels.LV1);
            
            GameObject newBuild = Object.Instantiate(pref, buyingParameters.ChoosedPosition.transform.position, Quaternion.identity);
            
            BuildsData buildsData = newBuild.GetComponent<BasicBuildingManager>().BuildsData;
            buildsData.PlacePosition = buyingParameters.ChoosedPosition;

            newBuild.transform.parent = LevelStructures.instance.StructuresContainer;
            LevelStructures.instance.StructuresOnScene.Add(newBuild);
            LevelStructures.instance.StructuresOnScene.Remove(buyingParameters.ChoosedPlatform);
            
            Object.Destroy(buyingParameters.ChoosedPlatform);
        }
        private GameObject FindStructureByType(StructureTypes buildingTypes, StructureLevels buildingLevel)
        {
            List<GameObject> buildsList = LevelPrefabs.instance.BuildsList;
            
            foreach (var build in buildsList)
            {
                BasicBuildingManager basicBuildingManager = build.GetComponent<BasicBuildingManager>();
                
                if (buildingTypes == basicBuildingManager.GetSavedStructureType() && buildingLevel == basicBuildingManager.GetSavedStructureLevel())
                {
                    return build;
                }
            }
            return null;
        }
    }
}