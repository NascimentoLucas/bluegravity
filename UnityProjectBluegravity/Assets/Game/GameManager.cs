using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Bluegravity.Game
{
    public class GameManager : MonoBehaviour
    {
        [Header("Setup")]
        [SerializeField]
        private Canvas _loadCanvas;
        [SerializeField]
        [Scene]
        private string _menuScene;

        private void Awake()
        {
            _loadCanvas.gameObject.SetActive(false);
        }

        public void GoToMenu()
        {
            _loadCanvas.gameObject.SetActive(true);
            SceneManager.LoadSceneAsync(_menuScene, LoadSceneMode.Single);
        }
    } 
}
