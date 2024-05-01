using UnityEngine;
using UnityEngine.Serialization;

namespace Entities.Structures.Platforms
{
    public abstract class BasicPlatformsManager : MonoBehaviour
    {
        [SerializeField] protected bool _isActive;
        [SerializeField] protected GameObject _spawnPoint;

        public GameObject SpawnPoint
        {
            get => _spawnPoint;
            set => _spawnPoint = value;
        }

        public abstract void OnMouseDown();
    }
}