using Bluegravity.Game.Economy;
using Bluegravity.Game.Inventory;
using System;
using UnityEngine;
using UnityEngine.Events;

namespace Bluegravity.Game.Save
{

    public class SaveManager : MonoBehaviour, ICurrencyCallback
    {
        public static SaveManager Instance;

        InventoryData _data;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                transform.parent = null;
                DontDestroyOnLoad(gameObject);
                _data = InventoryData.LoadJson();
            }
            else
            {
                Destroy(gameObject);
            }
        }

        private void Start()
        {
            EconomyControll.Instance.SetMoney(_data.GetGold());
            EconomyControll.Instance.AddCallback(this);
        }

        private void Save()
        {
            InventoryData.SaveToJson(_data);
        }

        internal void AddItem(string id)
        {
            _data.AddItem(id);
            Save();
        }

        internal void RemoveItem(string id)
        {
            _data.RemoveItem(id);
            Save();
        }

        public void CurrencyUpdated(float currency)
        {
            _data.SetGold(currency);
            Save();
        }

        internal bool IsPurchased(string id)
        {
            return _data.Contains(id);
        }

        public void IterateItens(UnityAction<InventoryItem> action)
        {
            _data.IterateItens(action);
        }
    }

}