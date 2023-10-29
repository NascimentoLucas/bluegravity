#if UNITY_EDITOR
using Bluegravity.Game.Player.Animation;
using Bluegravity.Game.Clothes;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Bluegravity.Dev
{
    public class ClotheDevWindown : EditorWindow
    {
        private PlayerClotheSO[] _clothes;
        private PlayerClothesBehaviour _clothesBehaviour;

        private Vector2 _scrollPos;

        [MenuItem("Bluegravity/Dev/" + nameof(ClotheDevWindown))]
        public static new void Show()
        {
            ClotheDevWindown wnd = GetWindow<ClotheDevWindown>();
            wnd.titleContent = new GUIContent(nameof(ClotheDevWindown));
        }

        private void OnGUI()
        {
            _scrollPos =
                EditorGUILayout.BeginScrollView(_scrollPos, GUILayout.Width(Screen.width),
                GUILayout.Height(Screen.height));

            try
            {
                _clothesBehaviour = EditorGUILayout.ObjectField(_clothesBehaviour, typeof(PlayerClothesBehaviour), true) as PlayerClothesBehaviour;

                if (_clothesBehaviour != null)
                {
                    GetClothes();

                    GUIContent buttonContent = new GUIContent("Use Clothe");
                    if (EditorGUILayout.DropdownButton(buttonContent, FocusType.Passive))
                    {
                        GenericMenu colorMenu = new GenericMenu();

                        for (int i = 0; i < _clothes.Length; i++)
                        {
                            int index = i; 
                            colorMenu.AddItem(new GUIContent(
                                $"{_clothes[index].Layer}: {_clothes[index].Texture.name}"), false,
                                () => _clothesBehaviour.SetClothe(_clothes[index]));
                        }

                        colorMenu.ShowAsContext();
                    }
                }

            }
            catch (Exception e)
            {
                Debug.LogException(e);
            }


            EditorGUILayout.EndScrollView();

        }

        private void GetClothes()
        {
            if (_clothes != null)
            {
                if (!GUILayout.Button("Refresh")) return;
            }

            try
            {
                string[] paths = AssetDatabase.FindAssets($"t:{nameof(PlayerClotheSO)}");
                _clothes = new PlayerClotheSO[paths.Length];

                for (int i = 0; i < _clothes.Length; i++)
                {
                    _clothes[i] = AssetDatabase.LoadAssetAtPath<PlayerClotheSO>(AssetDatabase.GUIDToAssetPath(paths[i]));
                }

            }
            catch (Exception e)
            {
                Debug.LogError(e);
                Debug.LogError($"Did not find {nameof(PlayerClotheSO)}");
            }
        }
    }
}
#endif