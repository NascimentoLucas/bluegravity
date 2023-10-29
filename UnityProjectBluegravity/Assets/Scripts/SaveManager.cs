using Bluegravity.Game.Economy;
using UnityEngine;

namespace Bluegravity.Game.Save
{

    public class SaveManager : MonoBehaviour, ICurrencyCallback
    {
        public static SaveManager Instance;

        [SerializeField]
        SaveData _data;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                transform.parent = null;
                DontDestroyOnLoad(gameObject);
                _data = new SaveData();
            }
            else
            {
                Destroy(gameObject);
            }
        }

        private void Start()
        {
            EconomyControll.Instance.AddCallback(this);
        }

        internal void AddItem(string id)
        {
            _data.AddItem(id);
        }

        internal void RemoveItem(string id)
        {
            _data.RemoveItem(id);
        }

        internal bool IsPurchased(string id)
        {
            return _data.Contains(id);
        }

        public void CurrencyUpdated(float currency)
        {
            _data.SetGold(currency);
        }
    }

}