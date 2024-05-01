using System;
using System.Linq;
using Systems.Events;
using Enteties.Buildings;
using TMPro;
using UI.Level;
using UnityEngine;
using UnityEngine.UI;

public class StructurePanelManager : BasicPanelManager
{
    [SerializeField] private TextMeshProUGUI _name;
    [SerializeField] private TextMeshProUGUI _level;
    [SerializeField] private TextMeshProUGUI _price;
    [SerializeField] private TextMeshProUGUI _information;
    [SerializeField] private GameObject _interactionButton;
    [SerializeField] private GameObject _destroyButton;
    [SerializeField] private GameObject _updateButton;

    private BasicBuildingManager _basicBuildingManager;
    private void Start()
    {
        Subscribe();
    }

    private void OnDestroy()
    {
        Unsubscribe();
    }

    private void Subscribe()
    {
        _destroyButton.GetComponent<Button>().onClick.AddListener(Destroy);
        _updateButton.GetComponent<Button>().onClick.AddListener(Improve);
        _interactionButton.GetComponent<Button>().onClick.AddListener(Manage);
        _close.onClick.AddListener(ClosePanel);   
    }

    private void Unsubscribe()
    {
        _destroyButton.GetComponent<Button>().onClick.RemoveListener(Destroy);
        _updateButton.GetComponent<Button>().onClick.RemoveListener(Improve);
        _interactionButton.GetComponent<Button>().onClick.RemoveListener(Manage);
        _close.onClick.RemoveListener(ClosePanel);  
    }
    
    
    public void AssemblePanel(BasicBuildingManager basicBuildingManager)
    {
        _basicBuildingManager = basicBuildingManager;
        BuildsData buildsData = _basicBuildingManager.BuildsData;
        _name.text = buildsData.BuildingType.ToString();
        _level.text = buildsData.BuildingLevel.ToString();
        _price.text = "Crystals: " + buildsData.UpdateCrystalsPrice + " Energy: " + buildsData.UpdateEnergyPrice + " Food: " + buildsData.UpdateFoodPrice;
        _information.text = buildsData.Information;
        BuildingLevels lastLevel = Enum.GetValues(typeof(BuildingLevels)).Cast<BuildingLevels>().Last();
        if (buildsData.BuildingLevel != lastLevel)
        {
            _updateButton.SetActive(true);
        }
        else
        {
            _updateButton.SetActive(false);
        }
        if (basicBuildingManager.CanBeDestroyed)
        {
            _destroyButton.SetActive(true);
        }
        else
        {
            _destroyButton.SetActive(false);
        }
        if (buildsData.IsInteractable)
        {
            _interactionButton.SetActive(true);
        }
        else
        {
            _interactionButton.SetActive(false);
        }

        if (basicBuildingManager.CanBeImproved)
        {
            _updateButton.SetActive(true);
        }
        else
        {
            _updateButton.SetActive(false);
        }
        
    }

    private void Manage()
    {
        if (_basicBuildingManager.BuildsData.BuildingType == BuildingTypes.Laboratory)
        {
            UIEventManager.ShowLaboratoryPanel();
            ClosePanel();
        }
        if (_basicBuildingManager.BuildsData.BuildingType == BuildingTypes.ArmyCreator)
        {
            UIEventManager.ShowTroopsProducerPanel();
            ClosePanel();
        }
    }
    private void Improve()
    {
        LevelEventManager.ImprovePressed(_basicBuildingManager);
    }
    private void Destroy()
    {
        LevelEventManager.CloseUI();
        gameObject.SetActive(false);
        LevelEventManager.StructureDestroy(_basicBuildingManager.gameObject);
    }
    
}
