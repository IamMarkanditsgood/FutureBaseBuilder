using Systems.Events;
using Entities.Army;
using MainLevel;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

namespace Level
{
    public class LevelManager : MonoBehaviour
    {
        [SerializeField] private LevelResources _levelResources;
        [SerializeField] private LevelArmy _levelArmy;
        [SerializeField] private LevelPrefabs _levelPrefabs;
        [SerializeField] private StructureManager _structureManager;
        

        [SerializeField] private GameObject _closingScenePanel;
        private readonly ArmyManager _armyManager = new ArmyManager();

        private bool _placingBuild;

        private void Awake()
        {
            Subscribe();
            Initialization();
        }

        private void OnDestroy()
        {
            UnSubscribe();
            Disable();
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
            LevelEventManager.OnUIPanelsClosed += CloseScenePanel;
            LevelEventManager.OnUIPanelsOpened += OpenScenePanel;

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
            LevelEventManager.OnUIPanelsClosed -= CloseScenePanel;
            LevelEventManager.OnUIPanelsOpened -= OpenScenePanel;
        }

        private void Initialization()
        {
            _levelResources.Init();
            _levelArmy.Init();
            _armyManager.Init();
            _structureManager.Init(_levelPrefabs,ref _levelResources);
        }

        private void Disable()
        {
            _armyManager.Disable();
        }
        private void CloseScenePanel()
        {
            _closingScenePanel.SetActive(false);
        }
        private void OpenScenePanel()
        {
            _closingScenePanel.SetActive(true);
        }
    }
}