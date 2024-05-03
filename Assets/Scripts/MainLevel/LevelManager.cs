using System;
using System.Collections.Generic;
using Systems;
using Systems.Events;
using Entities.Army;
using Entities.Structures;
using MainLevel.Data;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MainLevel
{
    public class LevelManager : MonoBehaviour
    {
        [SerializeField] private LevelResources _levelResources;
        [SerializeField] private LevelArmy _levelArmy;
        [SerializeField] private LevelPrefabs _levelPrefabs;
        [SerializeField] private LevelStructures _levelStructures;
        [SerializeField] private StructureManager _structureManager;
        [SerializeField] private SavedData _savedData;

        [SerializeField] private List<GameObject> _structurePositions;
        [SerializeField] private GameObject _closingSceneRoof;
        
        private readonly ArmyManager _armyManager = new ArmyManager();
        private readonly SaveLoadManager _saveLoadManager = new SaveLoadManager();
        private readonly SceneSaverLoader _sceneSaverLoader = new SceneSaverLoader();
        
        private void Awake()
        {
            Initialization();
            LoadScene();
            Subscribe();
        }

        private void OnDestroy()
        {
            UnSubscribe();
            Disable();
        }

        private void Subscribe()
        {
            SubscriptionStructureManager();
            SubscriptionLevelResources();
            SceneEventManager.OnSceneRoofOpen += DisableSceneInteraction;
            SceneEventManager.OnSceneRoofClose += EnableSceneInteraction;
            SceneEventManager.OnMainMenuPressed += MainMenu;

        }
        private void UnSubscribe()
        {
            UnsubscriptionStructureManager();
            UnsubscriptionLevelResources();
            SceneEventManager.OnSceneRoofOpen -= DisableSceneInteraction;
            SceneEventManager.OnSceneRoofClose -= EnableSceneInteraction;
            SceneEventManager.OnMainMenuPressed -= MainMenu;
        }

        private void SubscriptionStructureManager()
        {
            StructuresEventManager.OnStructureDestroyed += _structureManager.DestroyStructure;
            StructuresEventManager.OnPurchasedBuildCreate += _structureManager.CreatePurchasedBuild;
            StructuresEventManager.OnImprovePressed += _structureManager.ImproveStructure;
            SceneEventManager.OnBaseImprove += _structureManager.RepairPlatforms;
        }
        
        private void SubscriptionLevelResources()
        {
            ResourcesEventManager.OnResourceModify += _levelResources.ModifyResource;
        }
        
        private void UnsubscriptionStructureManager()
        {
            StructuresEventManager.OnStructureDestroyed -= _structureManager.DestroyStructure;
            StructuresEventManager.OnPurchasedBuildCreate -= _structureManager.CreatePurchasedBuild;
            StructuresEventManager.OnImprovePressed -= _structureManager.ImproveStructure;
            SceneEventManager.OnBaseImprove -= _structureManager.RepairPlatforms;
        }
        
        private void UnsubscriptionLevelResources()
        {
            ResourcesEventManager.OnResourceModify -= _levelResources.ModifyResource;
        }
        
        private void Initialization()
        {
            _sceneSaverLoader.Init(_structureManager,_structurePositions);
            _levelResources.Init();
            _levelArmy.Init();
            _levelPrefabs.Init();
            _levelStructures.Init();
            _armyManager.Init();
        }

        private void Disable()
        {
            _armyManager.Disable();
        }

        private void LoadScene()
        {
            try
            {
                _savedData = _saveLoadManager.LoadData<SavedData>("savedData.json");
                _sceneSaverLoader.ConfigureScene(_savedData);
                
            }
            catch (Exception e)
            {
                _savedData = new SavedData();
                Console.WriteLine(e);
            }
        }
        private void MainMenu()
        {
            _sceneSaverLoader.SaveData(_savedData);
            _saveLoadManager.SaveLevel(_savedData);
            SceneManager.LoadScene(0);
            
        }

        private void DisableSceneInteraction()
        {
            _closingSceneRoof.SetActive(false);
        }
        
        private void EnableSceneInteraction()
        {
            _closingSceneRoof.SetActive(true);
        }
        
    }
}