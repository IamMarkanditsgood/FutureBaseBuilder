using UnityEngine;

namespace Enteties.Buildings
{
    public class ArmyCreator : BasicBuildingManager, IDestroyable
    {
        public override void OnMouseDown()
        {
            Debug.Log("Good");
        }
        
        public void Destroy()
        {
            throw new System.NotImplementedException();
        }
    }
}