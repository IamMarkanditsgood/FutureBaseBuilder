using UnityEngine;
using UnityEngine.UI;

namespace UI.Level
{
    public abstract class BasicPanelManager: MonoBehaviour
    {
        [SerializeField] protected Button _close;
            

        protected void ClosePanel()
        {
            gameObject.SetActive(false);
        }
    }
}