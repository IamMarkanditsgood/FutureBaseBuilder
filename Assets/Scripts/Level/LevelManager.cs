using Systems.Events;
using UnityEngine;

namespace Level
{
    public class LevelManager : MonoBehaviour
    {
        [SerializeField] private LevelResources _levelResources;
        [SerializeField] private LevelPrefabs _levelPrefabs;
        [SerializeField] private StructureManager _structureManager;

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
            LevelEventManager.OnBuildBuyed += _structureManager.CreateBuild;
            LevelEventManager.OnImprovePressed += _structureManager.ImproveStructure;
            LevelEventManager.OnEnergyModify += _levelResources.ModifyEnergy;
            LevelEventManager.OnFoodModify += _levelResources.ModifyFood;
            LevelEventManager.OnСrystalsModify += _levelResources.ModifyCrystals;
            LevelEventManager.OnPowerModify += _levelResources.ModifyPower;
        }
        private void UnSubscribe()
        {
            LevelEventManager.OnStructureDestroyed -= _structureManager.DestroyStructure;
            LevelEventManager.OnBuildBuyed -= _structureManager.CreateBuild;
            LevelEventManager.OnImprovePressed -= _structureManager.ImproveStructure;
            LevelEventManager.OnEnergyModify -= _levelResources.ModifyEnergy;
            LevelEventManager.OnFoodModify -= _levelResources.ModifyFood;
            LevelEventManager.OnСrystalsModify -= _levelResources.ModifyCrystals;
            LevelEventManager.OnPowerModify -= _levelResources.ModifyPower;
        }

        private void Initialization()
        {
            _structureManager.Init(_levelPrefabs,ref _levelResources);
        }
    }
}