using Bluegravity.Game.Player.Animation;
using Bluegravity.Game.Clothes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Bluegravity.Game.NPC
{
    public class NPCBehaviour : MonoBehaviour, IAnimationHandler
    {
        [Header("Setup")]
        [SerializeField]
        private PlayerAnimationBehaviour _animation;
        [SerializeField]
        private PlayerClothesBehaviour _clothebehaviour;

        [Header("Setup.SO")]
        [SerializeField]
        private PlayerAnimationSO _mainAnimation;
        [SerializeField]
        private PlayerClotheSO[] _clothes;


        [Header("Setup")]
        [SerializeField]
        private Vector2 _direc = Vector2.right;

        private void Start()
        {
            _animation.SetAnimationHandler(this);
            _animation.PlayAnimation(PlayerStates.Idle);

            for (int i = 0; i < _clothes.Length; i++)
            {
                _clothebehaviour.SetClothe(_clothes[i]);
            }
        }

        public Vector2 GetDirection()
        {
            return _direc;
        }
    }

}