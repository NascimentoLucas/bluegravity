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
            ResetScroll();
        }

        public void Clear()
        {
            for (int i = _layout.transform.childCount - 1; i >= 0; i--)
            {
                Destroy(_layout.transform.GetChild(i).gameObject);
            }
        }




        #region UI Methods
        /// <summary>
        /// Call by animator
        /// </summary>
        public void ResetScroll()
        {
            _scroll.verticalNormalizedPosition = 1;
        } 
        #endregion
    }

}