using Bluegravity.Game.Player.Animation;
using Bluegravity.Game.Player.Input;
using Bluegravity.Game.Player.Movement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Bluegravity.Game.Player
{
    public class PlayerBehaviour : MonoBehaviour, IMovementControls
    {
        [Header("Setup")]
        [SerializeField]
        private PlayerMovementControl _movement;
        [SerializeField]
        private PlayerAnimationBehaviour _animation;
        PlayerInputBehaviour _inputActions;


        private void Start()
        {
            _movement.SetControl(this);
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
            _animation.SetDirection(_movement.Direction);

            if (GetMovement().x != 0 || GetMovement().y != 0)
            {
                _animation.UseAnimation(PlayerStates.Walk);
            }
            else
            {
                _animation.UseAnimation(PlayerStates.Idle);
            }
        }

        public Vector2 GetMovement()
        {
            return _inputActions.Default.Movement.ReadValue<Vector2>(); ;
        }
    }

}