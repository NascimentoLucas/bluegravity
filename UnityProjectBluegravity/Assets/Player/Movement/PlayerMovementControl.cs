using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Bluegravity.Game.Player.Movement
{
    public interface IMovementControls
    {
        Vector2 GetMovement();
    }

    /// <summary>
    /// Moves the <see cref="_playerTrans"/>.
    /// </summary>
    public class PlayerMovementControl : MonoBehaviour
    {
        [Header("Setup")]
        [SerializeField]
        private Rigidbody2D _playerBody;
        IMovementControls _controls;

        private Vector2 _delta;

        [Header("GD")]
        [SerializeField]
        private float _speed = 1;

        public Vector2 Direction => _delta.normalized;

        private void Awake()
        {
            enabled = _controls != null;
        }

        private void FixedUpdate()
        {
            _delta = _controls.GetMovement();
            _delta *= _speed;
            _playerBody.velocity = Vector2.zero;
            _playerBody.AddForce(_delta);
        }

        public void SetControl(IMovementControls controls)
        {
            _controls = controls;
            enabled = _controls != null;
        }
    }
}