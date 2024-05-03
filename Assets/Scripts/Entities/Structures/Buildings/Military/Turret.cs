using Systems.Events;
using Entities.Structures.Interfaces;
using MainLevel.Data;
using UnityEngine;

namespace Entities.Structures.Buildings.Military
{
    public class Turret : BasicBuildingManager, IBaseImprover
    {
        [SerializeField] private int _power;
        [SerializeField] private int[] _amountOfPowerForLevel;
        
        public override void OnMouseDown()
        {
            UIEventManager.ShowStructurePanel(this);
        }

        public void Improve()
        {
            _power += _amountOfPowerForLevel[(int) GetSavedStructureLevel()];
            ResourcesEventManager.ResourceModify(_power, ResourceTypes.Power);
        }
    }
}