using Systems.Events;
using Enteties.Buildings;
using UnityEngine;

namespace UI.Level
{
    public class UIPanelsManager : MonoBehaviour
    {
        [SerializeField] private GameObject _structurePanel;
        [SerializeField] private GameObject _shopPanel;
        [SerializeField] private GameObject _brokenPanelWarning;
        [SerializeField] private GameObject _laboratoryPanel;
    
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
            UIEventManager.OnShowStructurePanel += ShowStructurePanel;
            UIEventManager.OnShowShopPanel += ShowShopPanel;
            UIEventManager.OnBrakePlatformPressed += ShowBrokenPlatformWarning;
            UIEventManager.OnShowLaboratoryPanel += ShowLaboratoryPanel;
        }

        private void Unsubscribe()
        {
            UIEventManager.OnShowStructurePanel -= ShowStructurePanel;
            UIEventManager.OnShowShopPanel -= ShowShopPanel;
            UIEventManager.OnBrakePlatformPressed -= ShowBrokenPlatformWarning;
            UIEventManager.OnShowLaboratoryPanel -= ShowLaboratoryPanel;
        }

        private void ShowStructurePanel(BasicBuildingManager basicBuildingManager)
        {
            _structurePanel.SetActive(true);
            _structurePanel.GetComponent<StructurePanelManager>().AssemblePanel(basicBuildingManager);
        }
        private void ShowShopPanel(BuyingParameters buyingParameters)
        {
            _shopPanel.SetActive(true);
            _shopPanel.GetComponent<ShopPanelManager>().ConfigureShopPanel(buyingParameters);
        }

        private void ShowBrokenPlatformWarning()
        {
            _brokenPanelWarning.SetActive(true);
        }

        private void ShowLaboratoryPanel()
        {
            _laboratoryPanel.SetActive(true);
        }

    }
}
