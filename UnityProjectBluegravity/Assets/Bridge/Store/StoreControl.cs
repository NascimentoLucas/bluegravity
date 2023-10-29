using Bluegravity.Game.Item;
using Bluegravity.Game.Clothes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Bluegravity.Game.Player;
using UnityEngine.UI;

namespace Bluegravity.Game.Clothes
{
    public class StoreItem : IHandleItem
    {
        private PlayerClotheSO _clothe;

        public StoreItem(PlayerClotheSO playerClotheSO)
        {
            _clothe = playerClotheSO;
        }

        public void ButtonPressed()
        {
            PlayerBehaviour.Instance.WearClothe(_clothe);
        }
    }

    public class StoreControl : MonoBehaviour
    {
        private const string ShowKey = "Show";
        [Header("Setup")]
        [SerializeField]
        private ItensPanel _view;
        [SerializeField]
        private Animator _animator;
        [SerializeField]
        private Button _showStoreButton;

        [Header("GD")]
        [SerializeField]
        private PlayerClotheSO[] _clothes;


        private void Start()
        {
            _animator.SetBool(ShowKey, false);
            for (int i = 0; i < _clothes.Length; i++)
            {
                StoreItem item = new StoreItem(_clothes[i]);
                _view.CreateItem(item, _clothes[i]);
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
        }
        #endregion
    }

}