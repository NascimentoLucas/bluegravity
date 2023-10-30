using Bluegravity.Game.Player.Animation;
using UnityEngine;

namespace Bluegravity.Game.Clothes
{
    public class ClotheRender
    {
        private readonly SpriteRenderer _render;
        private AnimationSprites _animation;
        private PlayerClotheSO _so;

        public AnimationSprites Animation { get => _animation; }
        public SpriteRenderer Render { get => _render; }
        public PlayerClotheSO So { get => _so; }

        public ClotheRender(SpriteRenderer render)
        {
            _render = render;
        }

        internal void SetClothe(PlayerClotheSO so, int collum, int row)
        {
            _so = so;
            _animation = new AnimationSprites(_so.Texture, collum, row);
            _render.sortingOrder = so.Layer;
        }

        public void RemoveClothe()
        {
            _animation = null;
            _so = null;
            _render.sprite = null;
        }

        internal bool CanPlayAnimation()
        {
            return _animation != null;
        }
    }

}