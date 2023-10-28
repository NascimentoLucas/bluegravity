using System;
using System.Collections.Generic;
using UnityEngine;


namespace Bluegravity.Game.Player.Animation
{
    public class AnimationSprites
    {
        enum Directions
        {
            left,
            right,
            top,
            bottom,
        }

        List<Sprite> _sprites;
        int _collum;
        int _row;
        Texture2D _texture;

        public AnimationSprites(Texture2D texture, int collum, int row)
        {
            _sprites = new List<Sprite>();
            _texture = texture;
            _collum = collum;
            _row = row;

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

        private Directions GetDirection(Vector2 dirct)
        {
            if (dirct.x < 0)
                return Directions.left;
            if (dirct.x > 0)
                return Directions.right;
            if (dirct.y > 0)
                return Directions.top;

            return Directions.bottom;
        }

        private int GetIndex(int x, int y)
        {
            int index = x * (_collum);
            index += y;
            return index;
        }

        public Sprite[] GetSprites(PlayerStates state, Vector2 direction)
        {
            switch (state)
            {
                case PlayerStates.Idle:
                    int row = 4;
                    row += (int)GetDirection(direction);
                    int collum = 0;
                    //Debug.Log($"{GetDirection(direction)}: {row}/{GetIndex(row, collum)}");
                    return new Sprite[] { _sprites[GetIndex(row, collum)] };
                case PlayerStates.Walk:
                    throw new NotImplementedException();
                default:
                    throw new NotImplementedException();
            }
        }
    }
}
