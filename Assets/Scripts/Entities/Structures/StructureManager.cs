using System;
using System.Collections.Generic;
using Entities.Structures.Buildings;
using Entities.Structures.Data_and_Enams;
using UnityEngine;

namespace Entities.Structures
{
    [Serializable]
    public class StructureManager
    {
        [SerializeField] private List<Vector3> _structurePositions;
        [SerializeField] private BuildingLevels _maxStructureLevel;
        [SerializeField] private PlatformRepairer _platformRepairer;
        
        private StructureCreation _structureCreation = new StructureCreation();
        private StructureDestroying _structureDestroying = new StructureDestroying();
        private StructureImprovement _structureImprovement = new StructureImprovement();

        public void DestroyStructure(GameObject structure)
        {
            _structureDestroying.DestroyStructure(structure);
        }

        public void CreatePurchasedBuild(BuyingParameters buyingParameters)
        {
            _structureCreation.CreatePurchasedBuild(buyingParameters);
        }

        public void ImproveStructure(BasicBuildingManager basicBuildingManager)
        {
            _structureImprovement.ImproveStructure(basicBuildingManager, _maxStructureLevel);
        }
        
        public void RepairPlatforms(BuildingLevels baseLevel)
        {
            _platformRepairer.RepairPlatforms(baseLevel ,_maxStructureLevel);
        }
    }
}