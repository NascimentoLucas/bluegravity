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


        PlayerInputBehaviour _inputActions;


        private void Start()
        {
            _movement.SetControl(this);
        }

        public void OnEnable()
        {
            if (_inputActions == null)
            {
                _inputActions = new PlayerInputBehaviour();
            }
            _inputActions.Default.Enable();
        }

        public Vector2 GetMovement()
        {
            return _inputActions.Default.Movement.ReadValue<Vector2>(); ;
        }
    }

}