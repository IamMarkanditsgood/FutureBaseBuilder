using System;
using System.Collections.Generic;
using Entities.Structures.Buildings;
using Entities.Structures.Data_and_Enams;
using UnityEngine;

[Serializable]
public class LevelPrefabs
{
    public static LevelPrefabs instance;
    [SerializeField] private GameObject _foundament;
    [SerializeField] private GameObject _destroyedFoundament;
    [SerializeField] private List<GameObject> _buildsList;

    public GameObject Foundament => _foundament;
    public GameObject _DestroyedFoundament => _destroyedFoundament;
    public List<GameObject> BuildsList => _buildsList;

    public void Init()
    {
        instance = this;
    }
    
    public GameObject GetBuilding(BuildingTypes buildingTypes, BuildingLevels buildingLevels)
    {
        for (int i = 0; i < BuildsList.Count; i++)
        {
            if (BuildsList[i].GetComponent<BasicBuildingManager>().BuildsData.BuildingType == buildingTypes &&
                BuildsList[i].GetComponent<BasicBuildingManager>().BuildsData.BuildingLevel == buildingLevels)
            {
                return BuildsList[i];
            }
        }

        return null;
    }
}