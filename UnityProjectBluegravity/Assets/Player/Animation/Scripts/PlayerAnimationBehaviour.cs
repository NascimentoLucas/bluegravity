using System;
using UnityEngine;


namespace Bluegravity.Game.Player.Animation
{
    public enum PlayerStates
    {
        Idle,
        Walk,
        Run,
    }

    public class PlayerAnimationBehaviour : MonoBehaviour
    {

        [Header("Setup")]
        [SerializeField]
        private SpriteRenderer _spriteRenderer;


        [Header("Setup.Animation")]
        [SerializeField]
        private PlayerAnimation[] _animation;



        private float _animationTime;


        private void Awake()
        {
            Array.Sort(_animation);
        }

        private void Update()
        {
            _animationTime += Time.deltaTime;
            if (_animationTime > 1)
                _animationTime = 0;
        }

        public void UseAnimation(PlayerStates state)
        {
            int index = (int)state;

            if (index > _animation.Length - 1) return;

            _animation[index].UseAnimation(_spriteRenderer, _animationTime);
        }
    }
}
