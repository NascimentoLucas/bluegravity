using Bluegravity.Game.Item;
using Bluegravity.Game.Clothes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Bluegravity.Game.Player;
using UnityEngine.UI;

namespace Bluegravity.Game.Clothes
{

    public class StoreControl : MonoBehaviour
    {
        private const string ShowKey = "Show";

        [Header("Setup")]
        [SerializeField]
        private Animator _animator;
        [SerializeField]
        private Button _showStoreButton;

        [Header("Setup.Panel")]
        [SerializeField]
        private ItensPanel _buyPanel;
        [SerializeField]
        private ItensPanel _sellPanel;

        [Header("GD")]
        [SerializeField]
        private PlayerClotheSO[] _clothes;


        private void Start()
        {
            _animator.SetBool(ShowKey, false);
            _showStoreButton.gameObject.SetActive(false);
            for (int i = 0; i < _clothes.Length; i++)
            {
                StoreBuyItem item = new StoreBuyItem(_clothes[i]);
                _buyPanel.CreateItem(item, _clothes[i]);
            }

            for (int i = 0; i < 0; i++)
            {
                StoreSellItem item = new StoreSellItem(_clothes[i]);
                _sellPanel.CreateItem(item, _clothes[i]);
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            PlayerBehaviour player = other.gameObject.GetComponent<PlayerBehaviour>();
            if (player)
            {
                _showStoreButton.gameObject.SetActive(true);
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            PlayerBehaviour player = collision.gameObject.GetComponent<PlayerBehaviour>();
            if (player)
            {
                _animator.SetBool(ShowKey, false);
                _showStoreButton.gameObject.SetActive(false);
            }
        }

        #region UI Methods
        public void ShowView(bool value)
        {
            _animator.SetBool(ShowKey, value);
            _showStoreButton.gameObject.SetActive(!value);
        }
        #endregion
    }

}