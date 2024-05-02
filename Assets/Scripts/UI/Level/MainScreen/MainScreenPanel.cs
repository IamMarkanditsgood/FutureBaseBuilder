using System;
using System.Collections.Generic;
using Systems.Events;
using Entities.Army.Troops;
using MainLevel.Data;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Level.MainScreen
{
    public class MainScreenPanel : MonoBehaviour
    {
        [SerializeField] private Button _mainMenuButton;
    
        [SerializeField] private TextMeshProUGUI _crystals;
        [SerializeField] private TextMeshProUGUI _energy;
        [SerializeField] private TextMeshProUGUI _food;
        [SerializeField] private TextMeshProUGUI _power;
        [SerializeField] private TextMeshProUGUI _infantry;
        [SerializeField] private TextMeshProUGUI _apc;
        [SerializeField] private TextMeshProUGUI _tank;
        [SerializeField] private TextMeshProUGUI _helicopter;
        [SerializeField] private TextMeshProUGUI _plane;
        [SerializeField] private TextMeshProUGUI _robot;

        private Dictionary<ResourceTypes, int> _resources = new Dictionary<ResourceTypes, int>();
        private Dictionary<TroopTypes, int> _troops = new Dictionary<TroopTypes, int>();

        public void Start()
        {
            InitializeResourceDictionary();
            InitializeTroopDictionary();
            Subscribe();
            ConfigurePanel();
        }

        public void OnDestroy()
        {
            Unsubscribe();
        }

        private void InitializeResourceDictionary()
        {
            foreach (ResourceTypes type in Enum.GetValues(typeof(ResourceTypes)))
            {
                _resources[type] = 0;
            }
        }
        
        private void InitializeTroopDictionary()
        {
            foreach (TroopTypes type in Enum.GetValues(typeof(TroopTypes)))
            {
                _troops[type] = 0;
            }
        }
        private void Subscribe()
        {
            ResourcesEventManager.OnResourceModify += ModifyResource;
            TroopsProducingEvents.OnProducingFinished += ModifyTroop;
        }
        
        private void Unsubscribe()
        {
            ResourcesEventManager.OnResourceModify -= ModifyResource;
            TroopsProducingEvents.OnProducingFinished -= ModifyTroop;
              
        }

        public void ConfigurePanel()
        {
            ModifyResource(LevelResources.instance.Crystals, ResourceTypes.Crystals);
            ModifyResource(LevelResources.instance.Energy, ResourceTypes.Energy);
            ModifyResource(LevelResources.instance.Food, ResourceTypes.Food);
            ModifyResource(LevelResources.instance.BasePower, ResourceTypes.Power);
            ConfigureTroops();

        }
        #region Resources
        private void ModifyResource(int amount, ResourceTypes type)
        {
            _resources[type] += amount;
            UpdateResourceText(type);
        }
        
        private void UpdateResourceText(ResourceTypes type)
        {
            switch (type)
            {
                case ResourceTypes.Crystals:
                    _crystals.text = $"{_resources[type]}";
                    break;
                case ResourceTypes.Energy:
                    _energy.text = $"{_resources[type]}";
                    break;
                case ResourceTypes.Food:
                    _food.text = $"{_resources[type]}";
                    break;
                case ResourceTypes.Power:
                    _power.text = $"{_resources[type]}";
                    break;
            }
        }
        #endregion

        #region Troops

        private void ConfigureTroops()
        {
            foreach (TroopTypes type in Enum.GetValues(typeof(TroopTypes)))
            {
                _troops[type]  = GetTroopAmount(type);
            }
            foreach (TroopTypes type in Enum.GetValues(typeof(TroopTypes)))
            {
                UpdateTroopText(type);
            }
        }

        private int GetTroopAmount(TroopTypes type)
        {
            for (int i = 0; i < LevelArmy.instance.Troops.Count; i++)
            {
                if (type == LevelArmy.instance.Troops[i].Type)
                {
                    return LevelArmy.instance.Troops[i].NumberOfDivisions;
                }
            }

            return 0;
        }
    
        private void ModifyTroop(TroopTypes type)
        {
            _troops[type] += 1;
            UpdateTroopText(type);
        }
        
        private void UpdateTroopText(TroopTypes type)
        {
            switch (type)
            {
                case TroopTypes.Infantry:
                    _infantry.text = $"{_troops[type]}";
                    break;
                case TroopTypes.APC:
                    _apc.text = $"{_troops[type]}";
                    break;
                case TroopTypes.Tank:
                    _tank.text = $"{_troops[type]}";
                    break;
                case TroopTypes.Helicopter:
                    _helicopter.text = $"{_troops[type]}";
                    break;
                case TroopTypes.Plane:
                    _plane.text = $"{_troops[type]}";
                    break;
                case TroopTypes.Robot:
                    _robot.text = $"{_troops[type]}";
                    break;
            }
        }
        
        #endregion
    
    
    }
}
