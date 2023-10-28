using System;
using UnityEngine;


namespace Bluegravity.Game.Player.Animation
{
    public enum PlayerStates
    {
        Idle,
        Walk,
    }

    public interface IAnimationHandler
    {
        Vector2 GetDirection();
    }

    public class PlayerAnimationBehaviour : MonoBehaviour
    {
        [Header("Setup")]
        [SerializeField]
        private SpriteRenderer _spriteRenderer;
        private AnimationSprites _sprites;

        private PlayerAnimationSO _currentAnimation;
        private IAnimationHandler _animationHandler;
        private Sprite[] _currentFrames;


        [Header("Setup.Animation")]
        [SerializeField]
        private PlayerAnimationSO[] _animation;


        [Header("Setup.Sprite")]
        [SerializeField]
        private int _collum = 8;
        [SerializeField]
        private int _row = 8;


        private float _animationTime;

        public int Collum { get => _collum; }
        public int Row { get => _row; }

        private void Awake()
        {
            Array.Sort(_animation);
        }

        private void Start()
        {
            enabled = _animationHandler != null;
        }

        ///todo implements to the class manager the animation execution
        private void Update()
        {
            _animationTime += Time.deltaTime;
            if (_animationTime > 1)
            {
                _animationTime = 0;
            }

            Play();
        }

        private void Play()
        {
            _currentFrames = _sprites.GetSprites(
                _currentAnimation.State,
                _animationHandler.GetDirection());

            int index = (int)Mathf.Lerp(0, _currentFrames.Length, _animationTime);
            _spriteRenderer.sprite = _currentFrames[index];
        }

        /// <summary>
        /// If it contains an animation for the given state, 
        /// it will start play
        /// </summary>
        /// <param name="state"></param>
        public void PlayAnimation(PlayerStates state)
        {
            if (_animationHandler == null) return;

            int index = (int)state;
            if (index > _animation.Length - 1) return;
            if (_currentAnimation == _animation[index]) return;

            _currentAnimation = _animation[index];

            _sprites = new AnimationSprites(_currentAnimation.Texture, _collum, _row);
        }


        public void PlayParallelAnimation(AnimationSprites _sprites, SpriteRenderer spriteRenderer)
        {
            if (_currentAnimation == null) return;
            if (_animation == null) return;

            Sprite[] frames = _sprites.GetSprites(
                _currentAnimation.State,
                _animationHandler.GetDirection());
            int index = (int)Mathf.Lerp(0, frames.Length, _animationTime);
            spriteRenderer.sprite = frames[index];
        }

        public void SetAnimationHandler(IAnimationHandler handler)
        {
            _animationHandler = handler;
            enabled = _animationHandler != null;
        }
    }
}
