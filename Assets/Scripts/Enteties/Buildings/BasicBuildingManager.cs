using UnityEngine;

namespace Enteties.Buildings
{
    public abstract class BasicBuildingManager : MonoBehaviour
    {
        [SerializeField] protected BuildsData _buildsData;
        public abstract void OnMouseDown();
    }
}
