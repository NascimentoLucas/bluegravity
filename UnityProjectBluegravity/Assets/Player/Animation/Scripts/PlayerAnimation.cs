using System;
using UnityEngine;


namespace Bluegravity.Game.Player.Animation
{
    [CreateAssetMenu(fileName = nameof(PlayerAnimation), menuName = "ScriptableObjects/" + nameof(PlayerAnimation), order = 1)]
    public class PlayerAnimation : ScriptableObject, IComparable
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

            if (obj is PlayerAnimation animation)
            {
                int me = (int)_state;
                int other = (int)animation._state;
                return me.CompareTo(other);
            }


            throw new ArgumentException("Object is not a " + nameof(PlayerAnimation));
        }

        public virtual void UseAnimation(SpriteRenderer renderer, float time)
        {
            Sprite[] _sprites = _up;

            int index = (int)Mathf.Lerp(0, _sprites.Length, time);
            renderer.sprite = _sprites[index];
        }
    }
}
