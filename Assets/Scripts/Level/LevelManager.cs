using System.Collections;
using Systems.Events;
using UnityEngine;
using UnityEngine.Serialization;

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
    }
    private void UnSubscribe()
    {
        LevelEventManager.OnStructureDestroyed -= _structureManager.DestroyStructure;
        LevelEventManager.OnBuildBuyed -= _structureManager.CreateBuild;
    }

    private void Initialization()
    {
        _structureManager.Init(_levelPrefabs);
    }
}