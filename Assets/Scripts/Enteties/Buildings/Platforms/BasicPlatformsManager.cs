using System;
using UnityEngine;

namespace Enteties.Buildings.Platforms
{
    public abstract class BasicPlatformsManager : MonoBehaviour
    {
        [SerializeField] protected bool _isActive;
        [SerializeField] protected GameObject _spawnPosition;

        public GameObject SpawnPosition
        {
            get => _spawnPosition;
            set => _spawnPosition = value;
        }

        public abstract void OnMouseDown();
    }
}