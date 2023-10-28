#if UNITY_EDITOR
using Bluegravity.Game.Player.Animation;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Bluegravity.Dev
{
    public class SpriteCreatorDev : EditorWindow
    {
        Texture2D _texture;
        Vector2 _scrollPos;
        AnimationSprites _sprites;

        private int _collum;
        private int _row;

        [MenuItem("Bluegravity/Dev/" + nameof(SpriteCreatorDev))]
        public static new void Show()
        {
            SpriteCreatorDev wnd = GetWindow<SpriteCreatorDev>();
            wnd.titleContent = new GUIContent(nameof(SpriteCreatorDev));
        }

        private void OnGUI()
        {
            _scrollPos =
                EditorGUILayout.BeginScrollView(_scrollPos, GUILayout.Width(Screen.width),
                GUILayout.Height(Screen.height));

            try
            {
                _texture = EditorGUILayout.ObjectField(_texture, typeof(Texture2D), true) as Texture2D;

                _collum = EditorGUI.IntField(GUILayoutUtility.GetRect(25, 25), nameof(_collum), _collum);
                _row = EditorGUI.IntField(GUILayoutUtility.GetRect(25, 25), nameof(_row), _row);

                if (_collum > 0 && _row > 0 && _texture != null)
                {
                    if (GUILayout.Button("Split"))
                    {
                        _sprites = new AnimationSprites(_texture, _collum, _row);
                    }
                }

                if (_sprites != null)
                {

                    Vector2[] directions = new Vector2[]
                    {
                        Vector2.zero,
                        Vector2.left,
                        Vector2.right,
                        Vector2.down,
                        Vector2.up,
                    };

                    List<Sprite> frames = new List<Sprite>();
                    for (int i = 0; i < directions.Length; i++)
                    {
                        Sprite[] f = _sprites.GetSprites(PlayerStates.Idle, directions[i]);
                        for (int j = 0; j < f.Length; j++)
                        {
                            frames.Add(f[j]);
                        }

                    }


                    GUILayout.BeginHorizontal();

                    for (int j = 0; j < frames.Count; j++)
                    {
                        DrawOnGUISprite(frames[j]);
                    }

                    GUILayout.EndHorizontal();
                }
            }
            catch (Exception e)
            {
                Debug.LogException(e);
            }


            EditorGUILayout.EndScrollView();

        }

        /// <summary>
        /// <see href="https://discussions.unity.com/t/display-a-sprite-in-an-editorwindow/136865"/>
        /// </summary>
        /// <param name="aSprite"></param>
        void DrawOnGUISprite(Sprite aSprite)
        {
            Rect c = aSprite.rect;
            float spriteW = c.width;
            float spriteH = c.height;
            Rect rect = GUILayoutUtility.GetRect(spriteW, spriteH);
            var tex = aSprite.texture;
            c.xMin /= tex.width;
            c.xMax /= tex.width;
            c.yMin /= tex.height;
            c.yMax /= tex.height;
            GUI.DrawTextureWithTexCoords(rect, tex, c);
        }
    }
}
#endif