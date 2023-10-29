using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Bluegravity.Game.Economy
{
    public class CurrencyUI : MonoBehaviour, ICurrencyCallback
    {

        [Header("Setup")]
        [SerializeField]
        private RectTransform _father;
        [SerializeField]
        private TextMeshProUGUI _text;


        private void Start()
        {
            EconomyControll.Instance.AddCallback(this);
            CurrencyUpdated(EconomyControll.Instance.Currency);
        }

        private void OnDestroy()
        {
            EconomyControll.Instance.RemoveCallback(this);
        }

        public void CurrencyUpdated(float currency)
        {
            _text.text = currency.ToString("00.00");
            LayoutRebuilder.ForceRebuildLayoutImmediate(_text.rectTransform);
            LayoutRebuilder.ForceRebuildLayoutImmediate(_father);
        }
    }

}