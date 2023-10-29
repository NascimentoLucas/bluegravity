using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Bluegravity.Game.Item
{
    public class ItemPanel : MonoBehaviour
    {
        [Header("Setup")]
        [SerializeField]
        private ItemUICell _cellPrefab;
        [SerializeField]
        private LayoutGroup _layout;


        private void Start()
        {
            for (int i = 0; i < 25; i++)
            {
                Instantiate(_cellPrefab, _layout.transform);
            }
        }

    }

}