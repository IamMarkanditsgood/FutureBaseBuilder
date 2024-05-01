using Systems.Events;
using Entities.Structures.Buildings;
using Entities.Structures.Data_and_Enams;
using Entities.Structures.Interfaces;
using Level;
using UnityEngine;

namespace Entities.Structures
{
    public class StructureImprovement
    {
        public void ImproveStructure(BasicBuildingManager basicBuildingManager, BuildingLevels maxStructureLevel)
        {
            if (!basicBuildingManager.CanBeImproved)
            {
                return;
            }

            int updateCrystals = basicBuildingManager.BuildsData.UpdateCrystalsPrice;
            int updateEnergy = basicBuildingManager.BuildsData.UpdateEnergyPrice;
            int updateFood = basicBuildingManager.BuildsData.UpdateFoodPrice;
            
            if (LevelResources.instance.IsEnoughResources(updateCrystals,updateEnergy, updateFood))
            {
                SubtractionResources(updateCrystals, updateEnergy, updateFood);
                GameObject newBuild = SpawnBuild(basicBuildingManager);
                ToggleImprovementPossibility(newBuild, basicBuildingManager, maxStructureLevel);

                GameObject olderBuild = basicBuildingManager.gameObject;
                Object.Destroy(olderBuild);
                
                IsMainBaseImprovement(newBuild);

                UIEventManager.CloseAllPanels();
            }
        }

        private void SubtractionResources(int crystals, int energy, int food)
        {
            LevelEventManager.СrystalsModify(-crystals);
            LevelEventManager.FoodModify(-energy);
            LevelEventManager.EnergyModify(-food);
        }

        private GameObject SpawnBuild(BasicBuildingManager basicBuildingManager)
        {
            BuildingLevels nextBuildingLevel = basicBuildingManager.BuildsData.BuildingLevel + 1;
            BuildsData buildData = basicBuildingManager.BuildsData;
            Transform spawnPos = buildData.PlacePosition.transform;
               
            GameObject buildPref = LevelPrefabs.instance.GetBuilding(buildData.BuildingType, nextBuildingLevel);
            GameObject newBuild = Object.Instantiate(buildPref, spawnPos.position, Quaternion.identity);
                
            newBuild.GetComponent<BasicBuildingManager>().BuildsData.PlacePosition = buildData.PlacePosition;

            return newBuild;
        }

        private void ToggleImprovementPossibility(GameObject build,BasicBuildingManager basicBuildingManager, BuildingLevels maxStructureLevel)
        {
            if (basicBuildingManager.BuildsData.BuildingLevel + 1 == maxStructureLevel)
            {
                build.GetComponent<BasicBuildingManager>().CanBeImproved = false;
            }
        }

        private void IsMainBaseImprovement(GameObject newBuild)
        {
            if (newBuild.GetComponent<BasicBuildingManager>() is IBaseImprover)
            {
                IBaseImprover structure = (IBaseImprover)newBuild.GetComponent<BasicBuildingManager>();
                structure.Improve();
            }
        }
    }
}