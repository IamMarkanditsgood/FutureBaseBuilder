using UnityEngine;

namespace Enteties.Buildings
{
    public class Farm : BasicBuildingManager, IDestroyable, IImprovable, IManufacturer
    {
        public override void OnMouseDown()
        {
            Debug.Log("Good");
        }
        
        public void Destroy()
        {
            throw new System.NotImplementedException();
        }

        public void Improve()
        {
            throw new System.NotImplementedException();
        }

        public void Manufacture()
        {
            throw new System.NotImplementedException();
        }
    }
}