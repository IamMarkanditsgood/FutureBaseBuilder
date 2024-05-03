using System;
using System.Collections.Generic;
using Entities.Army.Troops;
using Entities.Structures.Data_and_Enams;
using UnityEngine;

namespace Systems
{
    [Serializable]
    public class SavedData
    {
        public List<int> troopAmount = new List<int>();
        public List<int> troopQueueAmount = new List<int>();
        public List<int> resourcesAmount = new List<int>();
        public List<StructureTypes> buildingsType= new List<StructureTypes>();
        public List<StructureLevels> buildingsLevel = new List<StructureLevels>();
        public List<Vector3>  buildsCoordinates = new List<Vector3>();
        public List<TroopTypes> researchedTroops  = new List<TroopTypes>();
        
        public void InitializeTroopAmountDictionary(int amount)
        {
            troopAmount.Add(amount);
        }
        public void InitializeTroopQueueAmountDictionary(int amount)
        {
            troopQueueAmount.Add(amount);
        }
        public void InitializeResourcesAmountDictionary(int amount)
        {
            resourcesAmount.Add(amount);
        }

        public void InitializeBuildingsType(StructureTypes type)
        {
            buildingsType.Add(type);
        }
        
        public void InitializeBuildingsLevel(StructureLevels level)
        {
            buildingsLevel.Add(level);
        }
        
        public void InitializeBuildsCoordinates(Vector3 coordinates)
        {
            buildsCoordinates.Add(coordinates);
                
        }
        
        public void InitializeResearchedTroops(List<TroopTypes> researchedList)
        {
            researchedTroops = researchedList;
                
        }

        public void CleanData()
        {
            troopAmount = new List<int>();
            troopQueueAmount = new List<int>();
            resourcesAmount = new List<int>();
            buildingsType= new List<StructureTypes>();
            buildingsLevel = new List<StructureLevels>();
            buildsCoordinates = new List<Vector3>();
            researchedTroops  = new List<TroopTypes>();
        }
    }
}