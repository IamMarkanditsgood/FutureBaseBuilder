﻿using Systems.Events;
using UnityEngine;

namespace Enteties.Buildings
{
    public class House : BasicBuildingManager, IDestroyable
    {
        public override void OnMouseDown()
        {
            UIEventManager.ShowStructurePanel(this);
        }
        
        public void Destroy()
        {
            throw new System.NotImplementedException();
        }
    }
}