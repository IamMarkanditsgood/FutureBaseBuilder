using Systems.Events;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Level
{
    public abstract class BasicPanelManager: MonoBehaviour
    {
        [SerializeField] protected Button _close;

        public BasicPanelManager()
        {
            UIEventManager.OnCloseAllPanels += ClosePanel;
        }
            
        protected void ClosePanel()
        {
            try
            {
                gameObject.SetActive(false);
            }
            catch
            {
                Debug.Log("Already have been switched off");
            }
        }
    }
}