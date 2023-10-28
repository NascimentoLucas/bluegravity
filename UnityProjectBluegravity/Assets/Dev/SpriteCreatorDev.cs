#if UNITY_EDITOR
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

                if (GUILayout.Button("Split"))
                {
                    _sprites = new List<Sprite>();
                    Sprite s = Sprite.Create(_texture,
                        new Rect(0.0f, 0.0f,
                        _texture.width, _texture.height),
                        new Vector2(0.5f, 0.5f),
                        100.0f);
                    _sprites.Add(s);
                }

                if (_sprites != null && _sprites.Count > 0)
                {
                    if (GUILayout.Button("Next"))
                    {
                        _count++;
                    }
                    DrawOnGUISprite(_sprites[_count % _sprites.Count]);
                }
            }
            catch
            {
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