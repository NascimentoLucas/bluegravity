using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

namespace Bluegravity.Game.Item
{
    public class ItensPanel : MonoBehaviour
    {
        [Header("Setup")]
        [SerializeField]
        private ItemUICell _cellPrefab;
        [SerializeField]
        private LayoutGroup _layout;
        [SerializeField]
        private ScrollRect _scroll;

        public void CreateItem(IPurchaseItem handle, IViewItem view)
        {
            ItemUICell cell = Instantiate(_cellPrefab, _layout.transform);
            cell.Setup(handle, view);
            _scroll.verticalNormalizedPosition = 0;
        }
    }

}