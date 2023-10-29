using Bluegravity.Game.Item;
using Bluegravity.Game.Clothes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Bluegravity.Game.Player;
using UnityEngine.UI;
using Bluegravity.Game.Save;
using Bluegravity.Game.Inventory;
using System;

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

        public PlayerClotheSO[] Clothes { get => _clothes;  }

        private void Start()
        {
            _animator.SetBool(ShowKey, false);
            _showStoreButton.gameObject.SetActive(false);
            for (int i = 0; i < _clothes.Length; i++)
            {
                StoreBuyItem item = new StoreBuyItem(_clothes[i], this);
                _buyPanel.CreateItem(item, _clothes[i]);
            }

            SetupInventory();
        }

        public void SetupInventory()
        {
            List<PlayerClotheSO> inventory = new List<PlayerClotheSO>();

            SaveManager.Instance.IterateItens(GetClothe);

            _sellPanel.Clear();

            for (int i = 0; i < inventory.Count; i++)
            {
                StoreSellItem item = new StoreSellItem(inventory[i], this);
                _sellPanel.CreateItem(item, item);
            }

            void GetClothe(InventoryItem item)
            {
                for (int i = 0; i < _clothes.Length; i++)
                {
                    if (_clothes[i].Id.Equals(item.Id))
                    {
                        if (item.Quantity > 0)
                        {
                            inventory.Add(_clothes[i]);
                        }
                        return;
                    }
                }
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
            if (value)
            {
                SetupInventory();
            }

            _animator.SetBool(ShowKey, value);
            _showStoreButton.gameObject.SetActive(!value);

        }
        #endregion
    }

}