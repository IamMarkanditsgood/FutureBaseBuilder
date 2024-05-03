using System;
using System.Collections.Generic;
using Systems;
using Entities.Structures.Buildings;
using Entities.Structures.Data_and_Enams;
using UI.Level.Panels.Shop;
using UnityEngine;

namespace Entities.Structures
{
    [Serializable]
    public class StructureManager
    {
        [SerializeField] private StructureLevels _maxStructureLevel;
        [SerializeField] private PlatformRepairer _platformRepairer;

        public PlatformRepairer PlatformRepairer
        {
            get => _platformRepairer;
            set => _platformRepairer = value;
        }

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
        
        public void RepairPlatforms(StructureLevels baseLevel)
        {
            _platformRepairer.RepairPlatforms(baseLevel ,_maxStructureLevel);
        }
    }
}