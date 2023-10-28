using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Bluegravity.Game.Player.Input;
using UnityEngine.InputSystem;

namespace Bluegravity.Game.Player.Movement
{
    public class PlayerMovementControl : MonoBehaviour
    {

        [Header("Setup")]
        [SerializeField]
        private Transform _playerTrans;

        private Vector2 delta;

        [Header("GD")]
        [SerializeField]
        private float _speed = 1;


        PlayerInputBehaviour _inputActions;

        public void OnEnable()
        {
            if (_inputActions == null)
            {
                _inputActions = new PlayerInputBehaviour();
            }
            _inputActions.Default.Enable();
        }

        private void Update()
        {
            delta = _inputActions.Default.Movement.ReadValue<Vector2>();
            delta *= _speed * Time.deltaTime;
            _playerTrans.position += new Vector3(delta.x, delta.y);
        }
    }
}