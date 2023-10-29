using Bluegravity.Game.Clothes;
using Bluegravity.Game.Inventory;
using Bluegravity.Game.Item;
using Bluegravity.Game.Save;
using Bluegravity.Game.View;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Bluegravity.Game.Player.Backpack
{

    public class BackpackBuyItem : IPurchaseItem, IViewItem
    {
        private PlayerClotheSO _clothe;

        public BackpackBuyItem(PlayerClotheSO playerClotheSO)
        {
            _clothe = playerClotheSO;
        }

        public Sprite GetIcon()
        {
            return _clothe.GetIcon();
        }

        public string GetName()
        {
            if (IsPurchased())
            {
                return _clothe.GetName();
            }
            else
            {
                return "Sold out";
            }
        }

        public float GetPrice()
        {
            return _clothe.GetPrice();
        }

        public bool IsPurchased()
        {
            return SaveManager.Instance.IsPurchased(_clothe.Id);
        }

        public void OnPressed()
        {
            if (IsPurchased())
            {
                PlayerBehaviour.Instance.WearClothe(_clothe);
            }
        }
    }

    public class PlayerBackpack : MonoBehaviour
    {

        [Header("Setup")]
        [SerializeField]
        private StoreControl _store;
        [SerializeField]
        private ItensPanel _view;
        [SerializeField]
        private AnimatorView _backpackAnimator;


        private void Start()
        {
            SetBackpack();
        }

        private void SetBackpack()
        {
            List<PlayerClotheSO> inventory = new List<PlayerClotheSO>();

            SaveManager.Instance.IterateItens(GetClothe);

            _view.Clear();

            for (int i = 0; i < inventory.Count; i++)
            {
                BackpackBuyItem item = new BackpackBuyItem(inventory[i]);
                _view.CreateItem(item, item);
            }

            void GetClothe(InventoryItem item)
            {
                for (int i = 0; i < _store.Clothes.Length; i++)
                {
                    if (_store.Clothes[i].Id.Equals(item.Id))
                    {
                        if (item.Quantity > 0)
                        {
                            inventory.Add(_store.Clothes[i]);
                        }
                        return;
                    }
                }
            }
        }

        #region UI Methods
        public void ShowBackpack(bool b)
        {
            if (b)
            {
                SetBackpack();
            }

            _backpackAnimator.Show(b);
        }
        #endregion

    }

}