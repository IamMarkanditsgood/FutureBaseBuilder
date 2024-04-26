using UnityEngine;
using UnityEngine.Serialization;

namespace Enteties.Buildings
{
    public abstract class BasicBuildingManager : MonoBehaviour
    {
        [SerializeField] protected BuildsData _buildsData;
        [SerializeField] protected bool _isInUse;
        [SerializeField] protected bool _canBeImproved = true;

        public bool IsInUse
        {
            get => _isInUse;
            set => _isInUse = value;
        }

        public bool CanBeImproved
        {
            get => _canBeImproved;
            set => _canBeImproved = value;
        }

        public BuildsData BuildsData
        {
            get { return _buildsData; }
            set { _buildsData = value; }
        }

        public abstract void OnMouseDown();
    }
}
