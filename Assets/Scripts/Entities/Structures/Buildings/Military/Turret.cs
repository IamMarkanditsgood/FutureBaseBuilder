using Systems.Events;
using Entities.Structures.Interfaces;
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
            _power += _amountOfPowerForLevel[(int) BuildsData.BuildingLevel];
            LevelEventManager.PowerModify(_power);
        }
    }
}