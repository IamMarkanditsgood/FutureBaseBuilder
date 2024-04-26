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

    public void CreateBuild(ByingParamethers byingParamethers)
    {
        GameObject pref = FindStructureByType(byingParamethers);
        pref = Object.Instantiate(pref, byingParamethers.ChoosetPosition.transform.position, Quaternion.identity);
        BuildsData buildsData = pref.GetComponent<BasicBuildingManager>().BuildsData;
        buildsData.PlacePosition = byingParamethers.ChoosetPosition;
        Object.Destroy(byingParamethers.ChoosedPlatform);
        
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
                if (newBuild.GetComponent<BasicBuildingManager>() is IImprovable)
                {
                    IImprovable structure = (IImprovable)newBuild.GetComponent<BasicBuildingManager>();
                    structure.Improve();
                }
                
                UIEventManager.CloseAllPanels();
            }
        }
    }
    public GameObject FindStructureByType(ByingParamethers byingParamethers)
    {
        for (int i = 0; i < _levelPrefabs.BuildsList.Count; i++)
        {
            if (byingParamethers.BuildingTypes == _levelPrefabs.BuildsList[i].GetComponent<BasicBuildingManager>()
                .BuildsData
                .BuildingType)
            {
                return _levelPrefabs.BuildsList[i];
            }
        }
        return null;
    }


}