using Bluegravity.Game.Player.Animation;
using Bluegravity.Game.Clothes;
using Bluegravity.Game.Player.Input;
using Bluegravity.Game.Player.Movement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Bluegravity.Game.Economy;
using Bluegravity.Game.Save;

namespace Bluegravity.Game.Player
{
    public class PlayerBehaviour : MonoBehaviour, IMovementControls, IAnimationHandler, ICurrencyCallback
    {
        public static PlayerBehaviour Instance { get; private set; }

        [Header("Setup")]
        [SerializeField]
        private PlayerMovementControl _movement;

        [SerializeField]
        private PlayerAnimationBehaviour _animation;
        [SerializeField]
        private PlayerClothesBehaviour _clothes;

        private PlayerInputBehaviour _inputActions;

        private void Awake()
        {
            Instance = this;
        }

        private void Start()
        {
            _movement.SetControl(this);
            _animation.SetAnimationHandler(this);
            EconomyControll.Instance.AddCallback(this);
        }

        private void OnEnable()
        {
            if (_inputActions == null)
            {
                _inputActions = new PlayerInputBehaviour();
            }
            _inputActions.Default.Enable();
        }

        private void OnDestroy()
        {
            EconomyControll.Instance.RemoveCallback(this);
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

        internal void WearClothe(PlayerClotheSO clothe)
        {
            _clothes.SetClothe(clothe);
        }

        public void CurrencyUpdated(float currency)
        {
            _clothes.IterateClothes(Check);

            void Check(ClotheRender clotheRen)
            {
                if (clotheRen.So == null) return;

                if (!SaveManager.Instance.IsPurchased(clotheRen.So.Id))
                {
                    clotheRen.RemoveClothe();
                }
            }
        }

        internal void MoveTo(Vector3 position)
        {
            _movement.MoveTo(position);
        }
    }

}