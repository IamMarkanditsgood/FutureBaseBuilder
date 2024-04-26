using System;
using UnityEngine;

[Serializable]
public struct LevelResources
{
    [SerializeField] private int _crystals;
    [SerializeField] private int _food;
    [SerializeField] private int _energy;

    public int Crystals => _crystals;
    public int Food => _food;
    public int Energy => _energy;
}