using System;
using System.Collections;
using System.Collections.Generic;
using Systems.Events;
using Entities.Army.Troops;
using Level;
using MainLevel;
using TMPro;
using UI.Level;
using UnityEngine;
using UnityEngine.UI;

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
    
    private int _crystalsAmount;
    private int _energyAmount;
    private int _foodAmount;
    private int _powerAmount;
    private int _infantryAmount;
    private int _apcAmount;
    private int _tankAmount;
    private int _helicopterAmount;
    private int _planeAmount;
    private int _robotAmount;
    

    public void Start()
    {
        Subscribe();
        ConfigurePanel();
    }

    public void OnDestroy()
    {
        Unsubscribe();
    }

    public void Subscribe()
    {
       LevelEventManager.OnСrystalsModify += ModifyCrystals;
       LevelEventManager.OnEnergyModify += ModifyEnergy;
       LevelEventManager.OnFoodModify += ModifyFood;
       LevelEventManager.OnPowerModify += ModifyPower;
       TroopsProducingEvents.OnProducingFinished += ModifyTroop;
    }
        
    public void Unsubscribe()
    {
        LevelEventManager.OnСrystalsModify -= ModifyCrystals;
        LevelEventManager.OnEnergyModify -= ModifyEnergy;
        LevelEventManager.OnFoodModify -= ModifyFood;
        LevelEventManager.OnPowerModify -= ModifyPower;
        TroopsProducingEvents.OnProducingFinished -= ModifyTroop;
              
    }

    public void ConfigurePanel()
    {
        ModifyCrystals(LevelResources.instance.Crystals);
        ModifyEnergy(LevelResources.instance.Energy);
        ModifyFood(LevelResources.instance.Food);
        ModifyPower(LevelResources.instance.BasePower);
        ConfigureTroops();

    }
    #region Resources
    private void ModifyCrystals(int amount)
    {
        _crystalsAmount += amount;
        _crystals.text = _crystalsAmount.ToString();
    }
    private void ModifyEnergy(int amount)
    {
        _energyAmount += amount;
        _energy.text = _energyAmount.ToString();
    }
    private void ModifyFood(int amount)
    {
        _foodAmount += amount;
        _food.text = _foodAmount.ToString();
    }
    private void ModifyPower(int amount)
    {
        _powerAmount += amount;
        _power.text = _powerAmount.ToString();
    }
    #endregion

    #region Troops

    private void ConfigureTroops()
    {
        _infantryAmount = GetTroopAmount(TroopTypes.Infantry);
        _apcAmount = GetTroopAmount(TroopTypes.APC);
        _tankAmount = GetTroopAmount(TroopTypes.Tank);
        _helicopterAmount = GetTroopAmount(TroopTypes.Helicopter);
        _planeAmount = GetTroopAmount(TroopTypes.Plane);
        _robotAmount = GetTroopAmount(TroopTypes.Robot);
        
        _infantry.text = _infantryAmount.ToString();
        _apc.text = _infantryAmount.ToString();
        _tank.text = _infantryAmount.ToString();
        _helicopter.text = _infantryAmount.ToString();
        _plane.text = _infantryAmount.ToString();
        _robot.text = _infantryAmount.ToString();
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
        switch (type)
        {
            case TroopTypes.Infantry:
                ModifyInfantry();
                break;
            case TroopTypes.APC:
                ModifyAPC();
                break;
            case TroopTypes.Tank:
                ModifyTank();
                break;
            case TroopTypes.Helicopter:
                ModifyHelicopter();
                break;
            case TroopTypes.Plane:
                ModifyPlane();
                break;
            case TroopTypes.Robot:
                ModifyRobot();
                break;
        }
    }
    
    private void ModifyInfantry()
    {
        _infantryAmount ++;
        _infantry.text = _infantryAmount.ToString();
    }
    
    private void ModifyAPC()
    {
        _apcAmount ++;
        _apc.text = _apcAmount.ToString();
    }
    
    private void ModifyTank()
    {
        _tankAmount ++;
        _tank.text = _tankAmount.ToString();
    }
    
    private void ModifyHelicopter()
    {
        _helicopterAmount ++;
        _helicopter.text = _helicopterAmount.ToString();
    }
    
    private void ModifyPlane()
    {
        _planeAmount ++;
        _plane.text = _planeAmount.ToString();
    }
    
    private void ModifyRobot()
    {
        _robotAmount ++;
        _robot.text = _robotAmount.ToString();
    }
    #endregion
    
    
}
