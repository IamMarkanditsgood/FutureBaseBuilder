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
        }

        private void Unsubscribe()
        {
            UIEventManager.OnShowStructurePanel -= ShowStructurePanel;
            UIEventManager.OnShowShopPanel -= ShowShopPanel;
            UIEventManager.OnBrakePlatformPressed -= ShowBrokenPlatformWarning;
        }

        private void ShowStructurePanel(BasicBuildingManager basicBuildingManager)
        {
            _structurePanel.SetActive(true);
            _structurePanel.GetComponent<StructurePanelManager>().AssemblePanel(basicBuildingManager);
        }
        private void ShowShopPanel(ByingParamethers byingParamethers)
        {
            _shopPanel.SetActive(true);
            _shopPanel.GetComponent<ShopPanelManager>().Init(byingParamethers);
        }

        private void ShowBrokenPlatformWarning()
        {
            _brokenPanelWarning.SetActive(true);
        }

    }
}
