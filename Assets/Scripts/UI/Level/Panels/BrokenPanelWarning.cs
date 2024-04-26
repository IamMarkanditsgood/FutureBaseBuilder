namespace UI.Level
{
    public class BrokenPanelWarning : BasicPanelManager
    {
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
            _close.onClick.AddListener(ClosePanel);   
        }

        private void Unsubscribe()
        {
            _close.onClick.RemoveListener(ClosePanel);    
        }
    }
}