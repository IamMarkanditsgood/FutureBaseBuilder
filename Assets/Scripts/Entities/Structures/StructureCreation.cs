using System.Collections.Generic;
using Entities.Structures.Buildings;
using Entities.Structures.Data_and_Enams;
using MainLevel.Data;
using UnityEngine;

namespace Entities.Structures
{
    public class StructureCreation
    {
        public void CreatePurchasedBuild(BuyingParameters buyingParameters)
        {
            GameObject pref = FindStructureByType(buyingParameters.BuildingTypes, BuildingLevels.Lv1);
            
            GameObject newBuild = Object.Instantiate(pref, buyingParameters.ChoosetPosition.transform.position, Quaternion.identity);
            
            BuildsData buildsData = newBuild.GetComponent<BasicBuildingManager>().BuildsData;
            buildsData.PlacePosition = buyingParameters.ChoosetPosition;
            
            Object.Destroy(buyingParameters.ChoosedPlatform);
        }
        private GameObject FindStructureByType(BuildingTypes buildingTypes, BuildingLevels buildingLevel)
        {
            List<GameObject> buildsList = LevelPrefabs.instance.BuildsList;
            
            foreach (var build in buildsList)
            {
                BuildsData buildsData = build.GetComponent<BasicBuildingManager>().BuildsData;
                
                if (buildingTypes == buildsData.BuildingType && buildingLevel == buildsData.BuildingLevel)
                {
                    return build;
                }
            }
            return null;
        }
    }
}