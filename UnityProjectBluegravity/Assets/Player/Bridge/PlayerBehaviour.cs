using Bluegravity.Game.Player.Animation;
using Bluegravity.Game.Player.Clothes;
using Bluegravity.Game.Player.Input;
using Bluegravity.Game.Player.Movement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Bluegravity.Game.Player
{
    public class PlayerBehaviour : MonoBehaviour, IMovementControls, IAnimationHandler
    {
        [Header("Setup")]
        [SerializeField]
        private PlayerMovementControl _movement;
        [SerializeField]
        private PlayerAnimationBehaviour _animation;
        [SerializeField]
        private PlayerClothesBehaviour _clothes;

        private PlayerInputBehaviour _inputActions;


        private void Start()
        {
            _movement.SetControl(this);
            _animation.SetAnimationHandler(this);
        }

        private void OnEnable()
        {
            if (_inputActions == null)
            {
                _inputActions = new PlayerInputBehaviour();
            }
            _inputActions.Default.Enable();
        }

        private void Update()
        {
            if (GetMovement().x != 0 || GetMovement().y != 0)
            {
                _animation.PlayAnimation(PlayerStates.Walk);
            }
            else
            {
                _animation.PlayAnimation(PlayerStates.Idle);
            }
        }

        public Vector2 GetMovement()
        {
            return _inputActions.Default.Movement.ReadValue<Vector2>(); ;
        }

        public Vector2 GetDirection()
        {
            return _movement.Direction;
        }
    }

}