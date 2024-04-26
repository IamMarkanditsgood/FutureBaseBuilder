using System;
using UnityEngine;

namespace Enteties.Buildings
{
    [Serializable]
    public struct BuildsData
    {
        [SerializeField] private BuildingTypes _buildingType;
        [SerializeField] private BuildingLevels _buildingLevel;
        [SerializeField] private bool _isInteractable;
        [SerializeField] private int _updatePrice;
        [TextAreaAttribute]
        [SerializeField] private string _notice;
    }
}