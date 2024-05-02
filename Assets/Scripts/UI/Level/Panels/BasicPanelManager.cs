using Systems.Events;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Level
{
    public abstract class BasicPanelManager: MonoBehaviour
    {
        [SerializeField] protected Button _close;
        [SerializeField] protected GameObject _panel;

        public BasicPanelManager()
        {
            UIEventManager.OnCloseAllPanels += ClosePanel;
        }
            
        protected void ClosePanel()
        {
            try
            {
                SceneEventManager.CloseSceneRoof();
                _panel.SetActive(false);
            }
            catch
            {
                Debug.Log("Already have been switched off");
            }
        }

        public virtual void Open()
        {
            SceneEventManager.OpenSceneRoof();
            _panel.SetActive(true);
        }
    }
}