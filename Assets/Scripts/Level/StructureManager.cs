using System;
using System.Collections.Generic;
using Enteties.Buildings;
using Enteties.Buildings.Platforms;
using UnityEngine;
using Object = UnityEngine.Object;

[Serializable]
public class StructureManager
{
    [SerializeField] private List<Vector3> _structurePositions;

    private LevelPrefabs _levelPrefabs;

    public void Init(LevelPrefabs levelPrefabs)
    {
        _levelPrefabs = levelPrefabs;
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