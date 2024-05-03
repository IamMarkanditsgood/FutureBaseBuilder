using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace UI.MainMenu
{
    public class MainMenuManager : MonoBehaviour
    {
        [SerializeField] private Button _start;
        [SerializeField] private Button _settings;
        [SerializeField] private Button _exit;

        private void Awake()
        {
            _start.onClick.AddListener(StartGame);
            _settings.onClick.AddListener(Settings);
            _exit.onClick.AddListener(Exit);
        }

        private void StartGame()
        {
            SceneManager.LoadScene(1);
        }
        private void Settings()
        {
            
        }
        private void Exit()
        {
            Application.Quit();
        }
    }
}
