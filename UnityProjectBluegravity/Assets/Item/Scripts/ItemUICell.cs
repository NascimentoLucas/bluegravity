using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Bluegravity.Game.Item
{
    public class ItemUICell : MonoBehaviour
    {
        [Header("Setup.Item")]
        [SerializeField]
        private Image _icon;
        [SerializeField]
        private TextMeshProUGUI _nameText;


        [Header("Setup.Price")]
        [SerializeField]
        private TextMeshProUGUI _priceText;

        private IHandleItem _handle;

        public void Setup(IHandleItem handle, IViewItem view)
        {
            _handle = handle;

            _icon.sprite = view.GetIcon();
            _nameText.text = view.GetName();
            _priceText.text = view.GetPrice().ToString("00.00");
        }

        #region UI Methods
        public void OnButtonPress()
        {
            _handle?.ButtonPressed();
        }
        #endregion
    }

}