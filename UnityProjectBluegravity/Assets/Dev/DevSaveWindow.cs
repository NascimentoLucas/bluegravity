#if UNITY_EDITOR
using Bluegravity.Game.Player.Animation;
using Bluegravity.Game.Clothes;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using Bluegravity.Game.Save;
using Bluegravity.Game.Inventory;

namespace Bluegravity.Dev
{
    public class DevSaveWindow : EditorWindow
    {
        private PlayerClotheSO[] _clothes;
        private PlayerClothesBehaviour _clothesBehaviour;

        private Vector2 _scrollPos;

        [MenuItem("Bluegravity/Dev/" + nameof(DevSaveWindow))]
        public static new void Show()
        {
            DevSaveWindow wnd = GetWindow<DevSaveWindow>();
            wnd.titleContent = new GUIContent(nameof(DevSaveWindow));
        }

        private void OnGUI()
        {
            _scrollPos =
                EditorGUILayout.BeginScrollView(_scrollPos, GUILayout.Width(Screen.width),
                GUILayout.Height(Screen.height));

            try
            {
                if (!EditorApplication.isPlaying)
                {
                    GUILayout.Label("Is not playing");
                    return;
                }

                if (SaveManager.Instance == null) return;

                SaveManager.Instance.IterateItens(ShowItem);


            }
            catch (Exception e)
            {
                Debug.LogException(e);
            }


            EditorGUILayout.EndScrollView();

        }

        private void ShowItem(InventoryItem item)
        {
            GUILayout.Box(item.Name);
            GUILayout.TextField(item.Id);
            GUILayout.TextField(item.Quantity.ToString());
        }
    }
}
#endif