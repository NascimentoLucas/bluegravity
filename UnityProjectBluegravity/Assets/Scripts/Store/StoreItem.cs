using Bluegravity.Game.Item;
using Bluegravity.Game.Player;
using Bluegravity.Game.Economy;
using Bluegravity.Game.Save;
using UnityEngine;

namespace Bluegravity.Game.Clothes
{
    public class StoreBuyItem : IPurchaseItem
    {
        private PlayerClotheSO _clothe;

        public StoreBuyItem(PlayerClotheSO playerClotheSO)
        {
            _clothe = playerClotheSO;
        }

        public bool IsPurchased()
        {
            return SaveManager.Instance.IsPurchased(_clothe.Id);
        }

        public void OnPressed()
        {
            if (EconomyControll.Instance.SpendMoney(_clothe.GetPrice()))
            {
                SaveManager.Instance.AddItem(_clothe.Id);
                PlayerBehaviour.Instance.WearClothe(_clothe);
            }
        }
    }


    public class StoreSellItem : IPurchaseItem, IViewItem
    {
        private PlayerClotheSO _clothe;
        private StoreControl _store;

        public StoreSellItem(PlayerClotheSO playerClotheSO, StoreControl store)
        {
            _clothe = playerClotheSO;
            _store = store;
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
                EconomyControll.Instance.AddMoney(_clothe.GetPrice());
                SaveManager.Instance.RemoveItem(_clothe.Id);
                _store.SetupInventory();
            }
        }
    }

}