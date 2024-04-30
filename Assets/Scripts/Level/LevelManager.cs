using Systems.Events;
using Enteties.Army;
using Unity.VisualScripting;
using UnityEngine;

namespace Level
{
    public class LevelManager : MonoBehaviour
    {
        [SerializeField] private LevelResources _levelResources;
        [SerializeField] private LevelArmy _levelArmy;
        [SerializeField] private LevelPrefabs _levelPrefabs;
        [SerializeField] private StructureManager _structureManager;
        [SerializeField] private ArmyManager _armyManager;

        [SerializeField] private GameObject _closingScenePanel;

        private bool _placingBuild;

        private void Awake()
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