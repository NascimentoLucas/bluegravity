using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Newtonsoft.Json;

namespace Bluegravity.Game.Inventory
{

    [Serializable]
    public class InventoryItem
    {
        public string Id;
        public string Name;
        public int Quantity;

        public InventoryItem()
        {
        }

        public InventoryItem(string id, string name)
        {
            Id = id;
            Name = name;
            Quantity = 1;
        }

        public InventoryItem(InventoryItem inventoryItem)
        {
            Id = inventoryItem.Id;
            Name = inventoryItem.Name;
            Quantity = inventoryItem.Quantity;
        }

        internal void Add(int quantity)
        {
            Quantity += quantity;
        }
    }

    [Serializable]
    public class Root
    {
        public float _gold;
        public Dictionary<string, InventoryItem> _itens;

        public Root(float gold, Dictionary<string, InventoryItem> itens)
        {
            _gold = gold;
            _itens = itens;
        }
    }


    [Serializable]
    public class InventoryData
    {
        private const string PrefsKey = "InventoryData";

        [SerializeField]
        private float _gold;

        [SerializeField]
        private Dictionary<string, InventoryItem> _itens = new Dictionary<string, InventoryItem>();

        public bool Contains(string id)
        {
            if (_itens.ContainsKey(id))
            {
                return _itens[id].Quantity > 0;
            }

            return false;
        }

        internal void IterateItens(UnityAction<InventoryItem> action)
        {
            if (action == null) return;

            foreach (var item in _itens.Keys)
            {
                action.Invoke(_itens[item]);
            }
        }

        public void RemoveItem(string id)
        {
            if (_itens.ContainsKey(id))
            {
                _itens[id].Add(-1);
                if (_itens[id].Quantity < 1)
                    _itens.Remove(id);
            }
        }

        public void AddItem(string id, string name = null)
        {
            if (_itens.ContainsKey(id))
            {
                _itens[id].Add(1);
            }
            else
            {
                if (string.IsNullOrEmpty(name))
                {
                    name = "Item";
                }
                _itens.Add(id, new InventoryItem(id, name));
            }
        }

        public void SetGold(float currency)
        {
            _gold = currency;
        }

        internal float GetGold()
        {
            return _gold;
        }

        internal static InventoryData LoadJson()
        {
            try
            {
                if (PlayerPrefs.HasKey(PrefsKey))
                {
                    string json = PlayerPrefs.GetString(PrefsKey);
                    Root r = JsonConvert.DeserializeObject<Root>(json);

                    InventoryData data = new InventoryData();
                    data._gold = r._gold;
                    foreach (var key in r._itens.Keys)
                    {
                        data._itens.Add(key, new InventoryItem(r._itens[key]));
                    }

                    return data;
                }
            }
            catch (Exception e)
            {
                Debug.LogError(e);
            }

            return new InventoryData();
        }


        internal static void SaveToJson(InventoryData data)
        {
            Root r = new Root(data._gold, data._itens);

            string json = JsonConvert.SerializeObject(r, Formatting.Indented);
            PlayerPrefs.SetString(PrefsKey, json);
        }
    }

}