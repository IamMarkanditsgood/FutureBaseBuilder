using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct LevelPrefabs
{
    [SerializeField] private GameObject _foundament;
    [SerializeField] private GameObject _destroyedFoundament;
    [SerializeField] private List<GameObject> _buildsList;

    public GameObject Foundament => _foundament;
    public GameObject _DestroyedFoundament => _destroyedFoundament;
    public List<GameObject> BuildsList => _buildsList;
}