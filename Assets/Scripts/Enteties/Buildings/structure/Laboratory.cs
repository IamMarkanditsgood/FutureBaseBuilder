﻿using UnityEngine;

namespace Enteties.Buildings
{
    public class Laboratory : BasicBuildingManager, IDestroyable, IImprovable
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
    }
}