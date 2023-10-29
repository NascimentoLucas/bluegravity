using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Bluegravity.Game.Inventory
{

    [Serializable]
    public class InventoryItem
    {
        [SerializeField]
        private readonly string _id;
        [SerializeField]
        private readonly string _name;
        [SerializeField]
        private int _quantity;

        public string Id => _id;
        public string Name => _name;
        public int Quantity => _quantity;


        public InventoryItem(string id, string name)
        {
            _id = id;
            _name = name;
            _quantity = 1;
        }


        internal void Add(int quantity)
        {
            _quantity += quantity;
        }
    }

    [Serializable]
    public class InventoryData
    {
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

        public void RemoveItem(string id)
        {
            if (Contains(id))
            {
                _itens[id].Add(-1);
                if (_itens[id].Quantity < 0)
                    _itens.Remove(id);
            }
        }

        internal void IterateItens(UnityAction<InventoryItem> action)
        {
            if (action == null) return;

            foreach (var item in _itens.Keys)
            {
                action.Invoke(_itens[item]);
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
    }

}