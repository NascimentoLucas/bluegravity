using Bluegravity.Game.Player.Animation;
using UnityEngine;

namespace Bluegravity.Game.Player.Clothes
{
    public class ClotheRender
    {
        private readonly SpriteRenderer _render;
        private AnimationSprites _animation;

        public AnimationSprites Animation { get => _animation; }
        public SpriteRenderer Render { get => _render; }

        public ClotheRender(SpriteRenderer render)
        {
            _render = render;
        }


        internal void SetClothe(PlayerClotheSO so, int collum, int row)
        {
            _animation = new AnimationSprites(so.Texture, collum, row);
            _render.renderingLayerMask = so.Layer;
        }

        internal bool CanPlayAnimation()
        {
            return _animation != null;
        }
    }

}