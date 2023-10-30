using Bluegravity.Game.Player.Animation;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Bluegravity.Game.Clothes
{
    public class PlayerClothesBehaviour : MonoBehaviour
    {
        public const int MaxLayer = 5;

        [Header("Setup")]
        [SerializeField]
        private ClotheRender[] _renderers;
        [SerializeField]
        private PlayerAnimationBehaviour _animation;
        private IAnimationHandler _animationHandler;


        private void Awake()
        {
            _renderers = new ClotheRender[MaxLayer];

            for (int i = 0; i < _renderers.Length; i++)
            {
                GameObject obj = new GameObject($"{nameof(ClotheRender)}.{i + 1}");
                obj.transform.parent = transform;
                obj.transform.localScale = transform.localScale;
                if (transform.parent != null)
                {
                    obj.transform.position = transform.parent.position;
                }
                SpriteRenderer render = obj.AddComponent<SpriteRenderer>();
                _renderers[i] = new ClotheRender(render);
            }
        }

        private void Update()
        {
            for (int i = 0; i < _renderers.Length; i++)
            {
                if (_renderers[i].CanPlayAnimation())
                {
                    _animation.PlayParallelAnimation(
                        _renderers[i].Animation,
                        _renderers[i].Render);
                }
            }
        }

        public void SetClothe(PlayerClotheSO so)
        {
            if (so.Layer - 1 < 0) return;
            if (so.Layer - 1 > MaxLayer - 1) return;

            _renderers[so.Layer - 1].SetClothe(so, _animation.Collum, _animation.Row);
        }
    }

}