using Systems.Events;
using Enteties.Buildings;
using UnityEngine;

namespace UI.Level
{
    public class UIPanelsManager : MonoBehaviour
    {
        [SerializeField] private GameObject _structurePanel;
    
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
            BuildsEventManager.OnShowStructurePanel += ShowStructurePanel;
        }

        private void Unsubscribe()
        {
            BuildsEventManager.OnShowStructurePanel -= ShowStructurePanel;
        }

        private void ShowStructurePanel(BuildsData basicBuildingManager)
        {
            _structurePanel.SetActive(true);
            SetPanel(basicBuildingManager);
        }

        private void SetPanel(BuildsData basicBuildingManager)
        {
            
        }
    
    }
}
