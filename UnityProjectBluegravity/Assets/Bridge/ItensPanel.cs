using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Bluegravity.Game.Item
{
    public class ItensPanel : MonoBehaviour
    {
        [Header("Setup")]
        [SerializeField]
        private ItemUICell _cellPrefab;
        [SerializeField]
        private LayoutGroup _layout;

        public void CreateItem(IHandleItem handle, IViewItem view)
        {
            ItemUICell cell = Instantiate(_cellPrefab, _layout.transform);
            cell.Setup(handle, view);
        }
    }

}