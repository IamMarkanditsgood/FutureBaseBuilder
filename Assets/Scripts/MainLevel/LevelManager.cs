using Systems.Events;
using Entities.Army;
using Entities.Structures;
using MainLevel.Data;
using UnityEngine;

namespace MainLevel
{
    public class LevelManager : MonoBehaviour
    {
        [SerializeField] private LevelResources _levelResources;
        [SerializeField] private LevelArmy _levelArmy;
        [SerializeField] private LevelPrefabs _levelPrefabs;
        
        [SerializeField] private StructureManager _structureManager;
        
        [SerializeField] private GameObject _closingSceneRoof;
        
        private readonly ArmyManager _armyManager = new ArmyManager();

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
            SubscriptionStructureManager();
            SubscriptionLevelResources();
            SceneEventManager.OnSceneRoofOpen += DisableSceneInteraction;
            SceneEventManager.OnSceneRoofClose += EnableSceneInteraction;

        }
        private void UnSubscribe()
        {
            UnsubscriptionStructureManager();
            UnsubscriptionLevelResources();
            SceneEventManager.OnSceneRoofOpen -= DisableSceneInteraction;
            SceneEventManager.OnSceneRoofClose -= EnableSceneInteraction;
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
            _levelResources.Init();
            _levelArmy.Init();
            _levelPrefabs.Init();
            _armyManager.Init();
        }

        private void Disable()
        {
            _armyManager.Disable();
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