using Systems.Events;
using Entities.Structures.Buildings;
using UI.Level.Panels.Shop;
using UI.Level.Panels.Structure;
using UnityEngine;

namespace UI.Level.Panels
{
    public class UIPanelsManager : MonoBehaviour
    {
        [SerializeField] private GameObject _structurePanel;
        [SerializeField] private GameObject _shopPanel;
        [SerializeField] private GameObject _brokenPanelWarning;
        [SerializeField] private GameObject _laboratoryPanel;
        [SerializeField] private GameObject _troopsProducerPanel;
    
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
            UIEventManager.OnShowTroopsProducerPanel += ShowTroopsProducerPanel;
        }

        private void Unsubscribe()
        {
            UIEventManager.OnShowStructurePanel -= ShowStructurePanel;
            UIEventManager.OnShowShopPanel -= ShowShopPanel;
            UIEventManager.OnBrakePlatformPressed -= ShowBrokenPlatformWarning;
            UIEventManager.OnShowLaboratoryPanel -= ShowLaboratoryPanel;
            UIEventManager.OnShowTroopsProducerPanel -= ShowTroopsProducerPanel;
        }

        private void ShowStructurePanel(BasicBuildingManager basicBuildingManager)
        {
            _structurePanel.GetComponent<BasicPanelManager>().Open();
            _structurePanel.GetComponent<StructurePanelManager>().AssemblePanel(basicBuildingManager);
        }
        private void ShowShopPanel(BuyingParameters buyingParameters)
        {
            _shopPanel.GetComponent<BasicPanelManager>().Open();
            _shopPanel.GetComponent<ShopPanelManager>().ConfigureShopPanel(buyingParameters);
        }

        private void ShowBrokenPlatformWarning()
        {
            _brokenPanelWarning.GetComponent<BasicPanelManager>().Open();
        }

        private void ShowLaboratoryPanel()
        {
            _laboratoryPanel.GetComponent<BasicPanelManager>().Open();
        }
        private void ShowTroopsProducerPanel()
        {
            _troopsProducerPanel.GetComponent<BasicPanelManager>().Open();
        }
    }
}
