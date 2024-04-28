using Systems.Events;
using Enteties.Army;
using UnityEngine;

namespace Level
{
    public class LevelManager : MonoBehaviour
    {
        [SerializeField] private LevelResources _levelResources;
        [SerializeField] private LevelPrefabs _levelPrefabs;
        [SerializeField] private StructureManager _structureManager;
        [SerializeField] private ArmyManager _armyManager;

        private bool _placingBuild;

        private void Start()
        {
            Subscribe();
            Initialization();
        }

        private void OnDestroy()
        {
            UnSubscribe();
        }

        private void Subscribe()
        {
            LevelEventManager.OnStructureDestroyed += _structureManager.DestroyStructure;
            LevelEventManager.OnPurchasedBuildCreate += _structureManager.CreatePurchasedBuild;
            LevelEventManager.OnImprovePressed += _structureManager.ImproveStructure;
            LevelEventManager.OnBaseImprove += _structureManager.RepairPlatforms;
            LevelEventManager.OnEnergyModify += _levelResources.ModifyEnergy;
            LevelEventManager.OnFoodModify += _levelResources.ModifyFood;
            LevelEventManager.OnСrystalsModify += _levelResources.ModifyCrystals;
            LevelEventManager.OnPowerModify += _levelResources.ModifyPower;
            
        }
        private void UnSubscribe()
        {
            LevelEventManager.OnStructureDestroyed -= _structureManager.DestroyStructure;
            LevelEventManager.OnPurchasedBuildCreate -= _structureManager.CreatePurchasedBuild;
            LevelEventManager.OnImprovePressed -= _structureManager.ImproveStructure;
            LevelEventManager.OnBaseImprove -= _structureManager.RepairPlatforms;
            LevelEventManager.OnEnergyModify -= _levelResources.ModifyEnergy;
            LevelEventManager.OnFoodModify -= _levelResources.ModifyFood;
            LevelEventManager.OnСrystalsModify -= _levelResources.ModifyCrystals;
            LevelEventManager.OnPowerModify -= _levelResources.ModifyPower;
        }

        private void Initialization()
        {
            _levelResources.Init();
            _armyManager.Init();
            _structureManager.Init(_levelPrefabs,ref _levelResources);
        }
    }
}