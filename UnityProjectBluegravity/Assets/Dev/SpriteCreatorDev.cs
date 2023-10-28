#if UNITY_EDITOR
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
        List<Sprite> _sprites;

        private int _collum;
        private int _row;

        int _count = 0;

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

                if (_collum > 0 && _row > 0)
                {
                    if (GUILayout.Button("Split"))
                    {
                        _sprites = new List<Sprite>();

                        int widht = _texture.width / _collum;
                        int height = _texture.height / _row;

                        for (int i = 0; i < _collum; i++)
                        {
                            for (int j = 0; j < _row; j++)
                            {
                                float y = i * height;
                                Sprite s = Sprite.Create(
                                    _texture,
                                    new Rect(j * widht, y,
                                    widht, height),
                                    new Vector2(0.5f, 0.5f),
                                    100.0f);

                                _sprites.Add(s);
                            }
                        }
                    }
                }

                if (_sprites != null && _sprites.Count > 0)
                {
                    GUILayout.BeginHorizontal();
                    if (GUILayout.Button("Next"))
                    {
                        _count += _collum;
                    }
                    if (GUILayout.Button("Back"))
                    {
                        _count -= _collum; ;
                        if (_count < 0)
                            _count = 0;
                    }
                    GUILayout.EndHorizontal();

                    GUILayout.BeginHorizontal();
                    for (int i = 0; i < _collum; i++)
                    {
                        GUILayout.Label((_count + i).ToString());
                        DrawOnGUISprite(_sprites[(_count + i) % _sprites.Count]);
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