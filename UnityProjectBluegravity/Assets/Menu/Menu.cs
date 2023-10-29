using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Bluegravity.Menu
{
    public class Menu : MonoBehaviour
    {
        [Header("Setup")]
        [SerializeField]
        private Canvas _startCanvas;
        [SerializeField]
        private Canvas _loadCanvas;
        
        [Header("Setup")]
        [SerializeField]
        [Scene]
        private string _gameScene;
        [Scene]
        [SerializeField]
        private string _devScene;

        private Canvas _currentCanvas;


        private void Start()
        {
            OpenCanvas(_startCanvas);
        }

        #region UI Methods
        public void OpenCanvas(Canvas canvas)
        {
            if (_currentCanvas != null)
                _currentCanvas.enabled = false;

            _currentCanvas = canvas;
            _currentCanvas.enabled = true;
        }

        public void GoToGame()
        {
            OpenCanvas(_loadCanvas);
            SceneManager.LoadSceneAsync(_gameScene, LoadSceneMode.Single);
        }

        public void GoToDev()
        {
            OpenCanvas(_loadCanvas);
            SceneManager.LoadSceneAsync(_devScene, LoadSceneMode.Single);
        }

        public void Quit()
        {
            Application.Quit();
        }
        #endregion
    }

}