using System;
using System.Linq;
using Systems.Events;
using Entities.Structures.Buildings;
using Entities.Structures.Data_and_Enams;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Level.Panels.Structure
{
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
            SetText(buildsData);
            SetButtons(buildsData);

        }

        private void SetText(BuildsData buildsData)
        {
            _name.text = buildsData.BuildingType.ToString();
            _level.text = buildsData.BuildingLevel.ToString();
            _price.text = "Crystals: " + buildsData.UpdateCrystalsPrice + " Energy: " + buildsData.UpdateEnergyPrice + " Food: " + buildsData.UpdateFoodPrice;
            _information.text = buildsData.Information;
        }

        private void SetButtons(BuildsData buildsData)
        {
            BuildingLevels lastLevel = Enum.GetValues(typeof(BuildingLevels)).Cast<BuildingLevels>().Last();
            
            _updateButton.SetActive(buildsData.BuildingLevel != lastLevel && _basicBuildingManager.CanBeImproved);
            _destroyButton.SetActive(_basicBuildingManager.CanBeDestroyed);
            _interactionButton.SetActive(buildsData.IsInteractable);
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
            StructuresEventManager.ImprovePressed(_basicBuildingManager);
        }
        private void Destroy()
        {
            SceneEventManager.CloseSceneRoof();
            gameObject.SetActive(false);
            StructuresEventManager.StructureDestroy(_basicBuildingManager.gameObject);
        }
    
    }
}
