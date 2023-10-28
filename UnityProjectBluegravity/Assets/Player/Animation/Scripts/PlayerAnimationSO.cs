using System;
using UnityEngine;


namespace Bluegravity.Game.Player.Animation
{

    [CreateAssetMenu(fileName = nameof(PlayerAnimationSO), menuName = "ScriptableObjects/" + nameof(PlayerAnimationSO), order = 1)]
    public class PlayerAnimationSO : ScriptableObject, IComparable
    {
        [Header("Setup")]
        [SerializeField]
        private PlayerStates _state;
        private AnimationSprites _sprites;


        [Header("Setup.Animations")]
        [SerializeField]
        private int _collum;
        [SerializeField]
        private int _row;
        [SerializeField]
        private Texture2D _texture;

        public PlayerStates State { get => _state; }

        public int CompareTo(object obj)
        {
            if (obj == null) return 1;

            if (obj is PlayerAnimationSO animation)
            {
                int me = (int)_state;
                int other = (int)animation._state;
                return me.CompareTo(other);
            }


            throw new ArgumentException("Object is not a " + nameof(PlayerAnimationSO));
        }

        /// <summary>
        /// Will be choose the animation that corresponds  to the given <paramref name="direction"/>.
        /// Moreover, the time will be utilized to select the frame from the animation.
        /// </summary>
        /// <param name="renderer"></param>
        /// <param name="time"></param>
        /// <param name="direction"></param>
        public void UseAnimation(SpriteRenderer renderer, float time, Vector2 direction)
        {
            if (_sprites == null)
                _sprites = new AnimationSprites(_texture, _collum, _row);
            if (direction == Vector2.zero) return;

            Sprite[] frames = _sprites.GetSprites(_state, direction);
            int index = (int)Mathf.Lerp(0, frames.Length, time);
            renderer.sprite = frames[index];
        }
    }
}
