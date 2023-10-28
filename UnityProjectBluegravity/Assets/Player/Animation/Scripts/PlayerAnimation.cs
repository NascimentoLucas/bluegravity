﻿using UnityEngine;


namespace Bluegravity.Game.Player.Animation
{
    [CreateAssetMenu(fileName = nameof(PlayerAnimation), menuName = "ScriptableObjects/" + nameof(PlayerAnimation), order = 1)]
    public class PlayerAnimation : ScriptableObject
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

        public virtual void UseAnimation(SpriteRenderer renderer, float time)
        {
            Sprite[]  _sprites = _up;

            int index = (int)Mathf.Lerp(0, _sprites.Length, time);
            renderer.sprite = _sprites[index];
        }
    }
}
