using System;
using System.Collections.Generic;
using Systems.Events;
using Enteties.Buildings;
using Enteties.Buildings.Platforms;
using Level;
using UnityEngine;
using Object = UnityEngine.Object;

[Serializable]
public class StructureManager
{
    [SerializeField] private List<Vector3> _structurePositions;
    [SerializeField] private BuildingLevels _maxLevel;
    [SerializeField] private List<BrokenPlatform> _brokenPlatforms;
    private LevelPrefabs _levelPrefabs;
    private LevelResources _levelResources;

    public void Init(LevelPrefabs levelPrefabs,ref LevelResources levelResources)
    {
        _levelPrefabs = levelPrefabs;
        _levelResources = levelResources;
    }

    public void DestroyStructure(GameObject structure)
    {
        GameObject platform = Object.Instantiate(_levelPrefabs.Foundament, structure.GetComponent<BasicBuildingManager>().BuildsData.PlacePosition.transform.position,
            structure.transform.rotation);
        platform.GetComponent<BasicPlatformsManager>().SpawnPosition = structure.GetComponent<BasicBuildingManager>().BuildsData.PlacePosition;
        Object.Destroy(structure);
    }

    public void CreatePurchasedBuild(BuyingParameters buyingParameters)
    {
        GameObject pref = FindStructureByType(buyingParameters.BuildingTypes, BuildingLevels.Lv1);
        pref = Object.Instantiate(pref, buyingParameters.ChoosetPosition.transform.position, Quaternion.identity);
        BuildsData buildsData = pref.GetComponent<BasicBuildingManager>().BuildsData;
        buildsData.PlacePosition = buyingParameters.ChoosetPosition;
        Object.Destroy(buyingParameters.ChoosedPlatform);
    }

    public void ImproveStructure(BasicBuildingManager basicBuildingManager)
    {
        if (basicBuildingManager.CanBeImproved)
        {
            if (basicBuildingManager.BuildsData.UpdateCrystalsPrice <= _levelResources.Crystals &&
                basicBuildingManager.BuildsData.UpdateEnergyPrice <= _levelResources.Energy &&
                basicBuildingManager.BuildsData.UpdateFoodPrice <= _levelResources.Food)
            {
                LevelEventManager.СrystalsModify(-basicBuildingManager.BuildsData.UpdateCrystalsPrice);
                LevelEventManager.FoodModify(-basicBuildingManager.BuildsData.UpdateFoodPrice);
                LevelEventManager.EnergyModify(-basicBuildingManager.BuildsData.UpdateEnergyPrice);
                GameObject buildPref = _levelPrefabs.GetBuilding(basicBuildingManager.BuildsData.BuildingType,
                    basicBuildingManager.BuildsData.BuildingLevel + 1);
                GameObject newBuild = Object.Instantiate(buildPref, basicBuildingManager.BuildsData.PlacePosition.transform.position, Quaternion.identity);
                newBuild.GetComponent<BasicBuildingManager>().BuildsData.PlacePosition = basicBuildingManager.BuildsData.PlacePosition;
                
                if (basicBuildingManager.BuildsData.BuildingLevel + 1 == _maxLevel)
                {
                    newBuild.GetComponent<BasicBuildingManager>().CanBeImproved = false;
                }
                Object.Destroy(basicBuildingManager.gameObject);
                if (newBuild.GetComponent<BasicBuildingManager>() is IBaseImprover)
                {
                    IBaseImprover structure = (IBaseImprover)newBuild.GetComponent<BasicBuildingManager>();
                    structure.Improve();
                }
                
                UIEventManager.CloseAllPanels();
            }
        }
    }
    public GameObject FindStructureByType(BuildingTypes buildingTypes, BuildingLevels buildingLevel)
    {
        for (int i = 0; i < _levelPrefabs.BuildsList.Count; i++)
        {
            BuildsData buildsData = _levelPrefabs.BuildsList[i].GetComponent<BasicBuildingManager>().BuildsData;
            if (buildingTypes == buildsData.BuildingType && buildingLevel == buildsData.BuildingLevel)
            {
                return _levelPrefabs.BuildsList[i];
            }
        }
        return null;
    }

    public void RepairPlatforms(BuildingLevels baseLevel)
    {
        List<BrokenPlatform> halfBrokenPlatforms = new List<BrokenPlatform>();
        if (baseLevel != _maxLevel)
        {
            for (int i = 0; i < _brokenPlatforms.Count / 2; i++)
            {
                halfBrokenPlatforms.Add(_brokenPlatforms[i]);
            }
        }
        else
        {
            for (int i = 0; i < _brokenPlatforms.Count; i++)
            {
                halfBrokenPlatforms.Add(_brokenPlatforms[i]);
            }
        }

        for (int i = 0; i < halfBrokenPlatforms.Count; i++)
        {
            GameObject newPlatform = Object.Instantiate(_levelPrefabs.Foundament, halfBrokenPlatforms[i].SpawnPosition.transform.position,
                Quaternion.identity);
            newPlatform.GetComponent<RepairedPlatform>().SpawnPosition = halfBrokenPlatforms[i].SpawnPosition;
            Object.Destroy(halfBrokenPlatforms[i].gameObject);
            _brokenPlatforms.Remove(halfBrokenPlatforms[i]);
        }
    }

}