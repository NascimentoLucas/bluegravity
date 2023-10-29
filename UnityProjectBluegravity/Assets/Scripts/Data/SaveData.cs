using System;
using System.Collections.Generic;
using UnityEngine;

namespace Bluegravity.Game.Save
{
    [Serializable]
    public class SaveData
    {
        [SerializeField]
        private float _gold;
        [SerializeField]
        private Dictionary<string, int> _itens = new Dictionary<string, int>();

        internal bool Contains(string id)
        {
            if (_itens.ContainsKey(id))
            {
                return _itens[id] > 0;
            }

            return false;
        }

        internal void RemoveItem(string id)
        {
            if (Contains(id))
            {
                _itens[id]--;
                if (_itens[id] < 0)
                    _itens.Remove(id);
            }
        }

        internal void AddItem(string id)
        {
            if (Contains(id))
            {
                _itens[id]++;
            }
            else
            {
                _itens.Add(id, 1);
            }
        }

        internal void SetGold(float currency)
        {
            _gold = currency;
        }
    }

}