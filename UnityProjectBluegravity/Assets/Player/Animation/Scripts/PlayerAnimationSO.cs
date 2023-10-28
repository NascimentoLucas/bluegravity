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


        [Header("Setup.Animations")]
        [SerializeField]
        private Sprite[] _up;
        [SerializeField]
        private Sprite[] _right;
        [SerializeField]
        private Sprite[] _down;
        [SerializeField]
        private Sprite[] _left;

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

        public virtual void UseAnimation(SpriteRenderer renderer, float time, Vector2 direction)
        {
            if (direction == Vector2.zero) return;

            Sprite[] _sprites = null;

            if (direction.x > 0)
                _sprites = _right;
            else if (direction.x < 0)
                _sprites = _left;

            if (direction.y > 0)
                _sprites = _up;
            else if (direction.y < 0)
                _sprites = _down;

            int index = (int)Mathf.Lerp(0, _sprites.Length, time);
            renderer.sprite = _sprites[index];
        }
    }
}
