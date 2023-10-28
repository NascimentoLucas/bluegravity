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

    public class PlayerMovementControl : MonoBehaviour
    {
        [Header("Setup")]
        [SerializeField]
        private Transform _playerTrans;

        private Vector2 _delta;

        [Header("GD")]
        [SerializeField]
        private float _speed = 1;


        IMovementControls _controls;

        public Vector2 XDirection => _delta.normalized;

        private void Awake()
        {
            enabled= _controls != null;
        }

        private void Update()
        {
            _delta = _controls.GetMovement();
            _delta *= _speed * Time.deltaTime;
            _playerTrans.position += new Vector3(_delta.x, _delta.y);
        }

        public void SetControl(IMovementControls controls)
        {
            _controls = controls;
            enabled = _controls != null;
        }
    }
}