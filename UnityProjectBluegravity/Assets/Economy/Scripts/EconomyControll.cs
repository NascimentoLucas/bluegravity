#if UNITY_EDITOR
using NaughtyAttributes;
#endif
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Bluegravity.Game.Economy
{
    public interface ICurrencyCallback
    {
        void CurrencyUpdated(float currency);
    }

    public class EconomyControll : MonoBehaviour
    {
        public static EconomyControll Instance { get; private set; }

        private List<ICurrencyCallback> _currencyChanges;

        private float _currency = 0;

        public string KeyCurrency { get => "KeyCurrency"; }
        public float Currency { get => _currency; }

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                transform.parent = null;
                _currencyChanges = new List<ICurrencyCallback>();
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
                return;
            }


            _currency = PlayerPrefs.GetFloat(KeyCurrency, 0);
        }

        public void AddMoney(float value)
        {
            _currency += value;
            PlayerPrefs.SetFloat(KeyCurrency, _currency);

            for (int i = 0; i < _currencyChanges.Count; i++)
            {
                try
                {
                    _currencyChanges[i].CurrencyUpdated(_currency);
                }
                catch (System.Exception e)
                {
                    Debug.LogException(e);
                }

            }
        }

        public bool SpendMoney(float value)
        {
            if (_currency - value < 0)
                return false;

            _currency -= value;
            PlayerPrefs.SetFloat(KeyCurrency, _currency);


            for (int i = 0; i < _currencyChanges.Count; i++)
            {
                try
                {
                    _currencyChanges[i].CurrencyUpdated(_currency);
                }
                catch (System.Exception e)
                {
                    Debug.LogException(e);
                }

            }

            return true;
        }

        public void AddCallback(ICurrencyCallback callback)
        {
            _currencyChanges.Add(callback);
        }


#if UNITY_EDITOR
        [Button]
        public void Add100()
        {
            AddMoney(100);
        }

        [Button]
        public void Spend100()
        {
            SpendMoney(100);
        }
#endif
    }

}